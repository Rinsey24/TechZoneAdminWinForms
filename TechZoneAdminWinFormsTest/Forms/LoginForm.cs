using MaterialSkin.Controls;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using TechZoneAdminWinFormsTest.Services;
using TechZoneAdminWinFormsTest.Utilities;
using TechZoneAdminWinFormsTest.Data.Entities;
using TechZoneAdminWinFormsTest.Data.UserEntities;
using MaterialMessageBox = TechZoneAdminWinFormsTest.Utilities.MaterialMessageBox;

namespace TechZoneAdminWinFormsTest.Forms
{
    public partial class LoginForm : MaterialForm
    {
        private readonly IAuthService _authService;
        private bool _useDarkTheme = false;

        public LoginForm(IAuthService authService, bool useDarkTheme = false)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _useDarkTheme = useDarkTheme;
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            ApplyTheme();
            ApplyLocalization();

            chkShowPassword.CheckedChanged += (s, e) =>
            {
                bool showPassword = chkShowPassword.Checked;
                txtPassword.UseSystemPasswordChar = !showPassword;
                txtPassword.PasswordChar = showPassword ? '\0' : '●';
                System.Diagnostics.Debug.WriteLine($"ShowPassword Checked: {showPassword}");
            };

            chkDarkTheme.CheckedChanged += (s, e) =>
            {
                _useDarkTheme = chkDarkTheme.Checked;
                ApplyTheme();
            };

            btnRegister.Click += (s, e) =>
            {
                new RegisterForm(_authService, _useDarkTheme).Show();
                this.Hide();
            };

            linkRu.LinkClicked += (s, e) => ChangeLanguage("ru");
            linkEn.LinkClicked += (s, e) => ChangeLanguage("en");

            this.Resize += LoginForm_Resize;
            LoginForm_Resize(this, EventArgs.Empty);
        }

        private void ApplyTheme()
        {
            MaterialSkinThemeColorsManager.ApplyTheme(this, _useDarkTheme);
        }

        private void LoginForm_Resize(object sender, EventArgs e)
        {
            panelCard.Left = (ClientSize.Width - panelCard.Width) / 2;
            panelCard.Top = (ClientSize.Height - panelCard.Height) / 2;

            btnLogin.Left = (panelCard.Width - btnLogin.Width) / 2;
            btnRegister.Left = (panelCard.Width - btnRegister.Width) / 2;

            linkEn.Left = ClientSize.Width - linkEn.Width - 10;
            linkRu.Top = linkEn.Top = ClientSize.Height - 30;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MaterialMessageBox.ShowError(Translate("FillAllFields"));
                return;
            }

            if (_authService.Login(username, password))
            {
                Admin loggedInAdmin = _authService.GetCurrentAdmin(); // Получаем объект Admin
                UsersContext context = new UsersContext(); // создаем контекст (если он не передается через DI)

                MaterialMessageBox.ShowInfo(Translate("LoginSuccess"));
                new MainForm(loggedInAdmin, context).Show(); // теперь 2 аргумента, как надо
                Hide();
            }

            else
            {
                MaterialMessageBox.ShowError(Translate("LoginFailed"));
            }
        }

        private void ChangeLanguage(string lang)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            ApplyLocalization();
        }

        private void ApplyLocalization()
        {
            Text = Translate("LoginTitle") ?? "Login";
            txtUsername.Hint = Translate("Username") ?? "Username";
            txtPassword.Hint = Translate("Password") ?? "Password";
            chkShowPassword.Text = Translate("ShowPassword") ?? "Show Password";
            chkDarkTheme.Text = Translate("DarkTheme") ?? "Dark Theme";
            btnLogin.Text = Translate("Login") ?? "Login";
            btnRegister.Text = Translate("Register") ?? "Register";
            linkRu.Text = Translate("LanguageRussian") ?? "Russian";
            linkEn.Text = Translate("LanguageEnglish") ?? "English";
        }

        private string Translate(string key)
        {
            return Properties.Resources.ResourceManager.GetString(key, Thread.CurrentThread.CurrentUICulture);
        }
    }
}