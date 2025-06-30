namespace TechZoneAdminWinFormsTest.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelContent;
        private MaterialSkin.Controls.MaterialButton btnUsers;
        private MaterialSkin.Controls.MaterialButton btnProducts;
        private MaterialSkin.Controls.MaterialButton btnSettings;
        private MaterialSkin.Controls.MaterialButton btnLogout;
        private System.Windows.Forms.LinkLabel linkRu;
        private System.Windows.Forms.LinkLabel linkEn;
        private System.Windows.Forms.PictureBox pictureProfile;
        private MaterialSkin.Controls.MaterialLabel lblAdminName;
        private MaterialSkin.Controls.MaterialButton btnToggleSidebar;
        private System.Windows.Forms.Timer sidebarTimer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnUsers = new MaterialSkin.Controls.MaterialButton();
            this.btnProducts = new MaterialSkin.Controls.MaterialButton();
            this.btnSettings = new MaterialSkin.Controls.MaterialButton();
            this.btnLogout = new MaterialSkin.Controls.MaterialButton();
            this.btnToggleSidebar = new MaterialSkin.Controls.MaterialButton();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.pictureProfile = new System.Windows.Forms.PictureBox();
            this.lblAdminName = new MaterialSkin.Controls.MaterialLabel();
            this.linkRu = new System.Windows.Forms.LinkLabel();
            this.linkEn = new System.Windows.Forms.LinkLabel();
            this.sidebarTimer = new System.Windows.Forms.Timer(this.components);

            this.panelSidebar.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfile)).BeginInit();
            this.SuspendLayout();

            // panelSidebar
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.panelSidebar.Controls.Add(this.btnToggleSidebar);
            this.panelSidebar.Controls.Add(this.btnUsers);
            this.panelSidebar.Controls.Add(this.btnProducts);
            this.panelSidebar.Controls.Add(this.btnSettings);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Size = new System.Drawing.Size(200, 600);

            // btnUsers
            this.btnUsers.Text = "Пользователи";
            this.btnUsers.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnUsers.Location = new System.Drawing.Point(10, 50);
            this.btnUsers.Size = new System.Drawing.Size(180, 40);
            this.btnUsers.UseAccentColor = true;

            // btnProducts
            this.btnProducts.Text = "Товары";
            this.btnProducts.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnProducts.Location = new System.Drawing.Point(10, 100);
            this.btnProducts.Size = new System.Drawing.Size(180, 40);
            this.btnProducts.UseAccentColor = true;

            // btnSettings
            this.btnSettings.Text = "Настройки";
            this.btnSettings.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnSettings.Location = new System.Drawing.Point(10, 150);
            this.btnSettings.Size = new System.Drawing.Size(180, 40);
            this.btnSettings.UseAccentColor = true;

            // btnLogout
            this.btnLogout.Text = "Выход";
            this.btnLogout.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnLogout.Location = new System.Drawing.Point(10, 500);
            this.btnLogout.Size = new System.Drawing.Size(180, 40);
            this.btnLogout.UseAccentColor = true;

            // btnToggleSidebar
            this.btnToggleSidebar.Text = "<<";
            this.btnToggleSidebar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnToggleSidebar.Location = new System.Drawing.Point(10, 10);
            this.btnToggleSidebar.Size = new System.Drawing.Size(180, 30);
            this.btnToggleSidebar.UseAccentColor = true;

            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(200, 0);
            this.panelHeader.Size = new System.Drawing.Size(600, 80);

            // panelContent
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Dock = DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(200, 80);
            this.panelContent.Size = new System.Drawing.Size(600, 520);

            // pictureProfile
            this.pictureProfile.Location = new System.Drawing.Point(210, 90);
            this.pictureProfile.Size = new System.Drawing.Size(40, 40);
            this.pictureProfile.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureProfile.BorderStyle = BorderStyle.FixedSingle;

            // lblAdminName
            this.lblAdminName.Text = "Админ";
            this.lblAdminName.AutoSize = true;
            this.lblAdminName.Location = new System.Drawing.Point(260, 90);

            // linkRu
            this.linkRu.Text = "Русский";
            this.linkRu.Location = new System.Drawing.Point(10, 570);
            this.linkRu.Size = new System.Drawing.Size(70, 20);
            this.linkRu.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            // linkEn
            this.linkEn.Text = "English";
            this.linkEn.Location = new System.Drawing.Point(730, 570);
            this.linkEn.Size = new System.Drawing.Size(70, 20);
            this.linkEn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // sidebarTimer
            this.sidebarTimer.Interval = 20;

            // MainForm
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.pictureProfile);
            this.Controls.Add(this.lblAdminName);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.linkRu);
            this.Controls.Add(this.linkEn);
            this.BackColor = System.Drawing.Color.White;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "TechZone Admin";

            this.panelSidebar.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfile)).EndInit();
            this.ResumeLayout(false);
        }
    }
}