using MaterialSkin;
using MaterialSkin.Controls;
using System.Drawing.Drawing2D;
using System.Text.Json;
using TechZoneAdminWinFormsTest.Properties;
using TechZoneAdminWinFormsTest.Utilities;
using TechZoneAdminWinFormsTest.Services;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TechZoneAdminWinFormsTest.Data.UserEntities;
using System.Threading;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using TechZoneAdminWinFormsTest.Forms; // обязательно для доступа к ProductsForm и UsersForm
using MaterialMessageBox = TechZoneAdminWinFormsTest.Utilities.MaterialMessageBox;

namespace TechZoneAdminWinFormsTest.Forms
{
    public partial class MainForm : MaterialForm
    {
        private readonly Admin _admin;
        private AppSettings _settings;
        private readonly string _settingsPath = Path.Combine(AppContext.BaseDirectory, "Properties", "appsettings.json");
        private readonly UsersContext _context;
        private readonly AdminService _adminService;

        public MainForm(Admin admin, UsersContext context)
        {
            InitializeComponent();
            _admin = admin ?? throw new ArgumentNullException(nameof(admin));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _adminService = new AdminService(_context);

            _settings = LoadAppSettings();
            MaterialSkinThemeColorsManager.ApplyTheme(this, _settings.DarkTheme);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(_settings.Language ?? "en");
            Thread.CurrentThread.CurrentCulture = new CultureInfo(_settings.Language ?? "en");

            ApplyLocalization();
            LoadUserProfile();
            ShowContent("Welcome");

            btnUsers.Click += (_, _) => ShowContent("Users");
            btnProducts.Click += (_, _) => ShowContent("Products");
            btnSettings.Click += (_, _) => ShowContent("Settings");
            btnLogout.Click += (_, _) => Logout();
            linkRu.Click += (_, _) => ChangeLanguage("ru");
            linkEn.Click += (_, _) => ChangeLanguage("en");
        }

        private AppSettings LoadAppSettings()
        {
            if (!File.Exists(_settingsPath)) return new AppSettings();
            var json = File.ReadAllText(_settingsPath);
            return JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
        }

        private void LoadUserProfile()
        {
            string imagePath = string.IsNullOrEmpty(_admin.ProfileImage)
                ? Path.Combine(Application.StartupPath, "Resources", "Images", "default.jpg")
                : _admin.ProfileImage;

            if (File.Exists(imagePath))
            {
                pictureProfile.Image = Image.FromFile(imagePath);
                MakeAvatarCircular();
            }
            else
            {
                pictureProfile.Image = Resources.DefaultProfileImage;
            }
            lblAdminName.Text = _admin.DisplayName ?? _admin.Username;
        }

        private void MakeAvatarCircular()
        {
            int diameter = Math.Min(pictureProfile.Width, pictureProfile.Height);
            using var bmp = new Bitmap(diameter, diameter);
            using var g = Graphics.FromImage(bmp);
            using var path = new GraphicsPath();

            g.SmoothingMode = SmoothingMode.AntiAlias;
            path.AddEllipse(0, 0, diameter, diameter);
            g.SetClip(path);
            g.DrawImage(pictureProfile.Image, 0, 0, diameter, diameter);

            pictureProfile.Image = new Bitmap(bmp);
            pictureProfile.Region = new Region(path);
        }

        private void ShowContent(string contentType)
        {
            panelContent.Controls.Clear();

            switch (contentType)
            {
                case "Settings":
                    var settingsControl = new SettingsForm(_admin, _adminService, SaveAdminChanges)
                    {
                        Dock = DockStyle.Fill
                    };
                    panelContent.Controls.Add(settingsControl);
                    break;

                case "Products":
                    var productsControl = new ProductsForm
                    {
                        Dock = DockStyle.Fill
                    };
                    panelContent.Controls.Add(productsControl);
                    break;

                case "Users":
                    var usersForm = new UsersForm(_settings.DarkTheme) // Передаём текущую тему
                    {
                        TopLevel = false,
                        FormBorderStyle = FormBorderStyle.None,
                        Dock = DockStyle.Fill
                    };
                    usersForm.Show();
                    panelContent.Controls.Add(usersForm);
                    break;

                default:
                    var welcomeLabel = new MaterialLabel
                    {
                        Text = string.Format(Translate("WelcomeUser"), _admin.DisplayName ?? _admin.Username),
                        AutoSize = true,
                        Location = new Point(20, 20)
                    };
                    panelContent.Controls.Add(welcomeLabel);
                    break;
            }
        }

        private void SaveAdminChanges(Admin updatedAdmin)
        {
            _admin.DisplayName = updatedAdmin.DisplayName;
            _admin.ProfileImage = updatedAdmin.ProfileImage;
            LoadUserProfile();
        }

        private void Logout()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_settingsPath));
            File.WriteAllText(_settingsPath, JsonSerializer.Serialize(_settings, new JsonSerializerOptions { WriteIndented = true }));
            MaterialMessageBox.ShowInfo(Translate("LogoutMessage"));
            var dbContext = new UsersContext(new DbContextOptionsBuilder<UsersContext>().UseSqlite("Data Source=C:\\TechZone\\users.db").Options);
            var authService = new AuthService(dbContext);
            new LoginForm(authService, _settings.DarkTheme).Show();
            Close();
        }

        private void ChangeLanguage(string languageCode)
        {
            _settings.Language = languageCode;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageCode);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(languageCode);
            ApplyLocalization();
            Directory.CreateDirectory(Path.GetDirectoryName(_settingsPath));
            File.WriteAllText(_settingsPath, JsonSerializer.Serialize(_settings, new JsonSerializerOptions { WriteIndented = true }));
            ShowContent(panelContent.Controls.Count > 0 && panelContent.Controls[0] is SettingsForm ? "Settings" : "Welcome");
        }

        public void RefreshThemeAndLocalization()
        {
            _settings = LoadAppSettings();
            MaterialSkinThemeColorsManager.ApplyTheme(this, _settings.DarkTheme);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(_settings.Language ?? "en");
            Thread.CurrentThread.CurrentCulture = new CultureInfo(_settings.Language ?? "en");
            ApplyLocalization();
            LoadUserProfile();
            ShowContent(panelContent.Controls.Count > 0 && panelContent.Controls[0] is SettingsForm ? "Settings" : "Welcome");
        }

        private void ApplyLocalization()
        {
            Text = Translate("MainTitle");
            btnUsers.Text = Translate("MenuUsers");
            btnProducts.Text = Translate("MenuProducts");
            btnSettings.Text = Translate("MenuSettings");
            btnLogout.Text = Translate("MenuLogout");
            linkRu.Text = Translate("LanguageRussian");
            linkEn.Text = Translate("LanguageEnglish");
            lblAdminName.Text = _admin.DisplayName ?? _admin.Username;
        }

        private string Translate(string key)
        {
            return Resources.ResourceManager.GetString(key, Thread.CurrentThread.CurrentUICulture) ?? key;
        }
    }
}