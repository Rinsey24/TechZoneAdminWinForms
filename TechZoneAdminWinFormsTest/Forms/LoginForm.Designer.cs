namespace TechZoneAdminWinFormsTest.Forms
{
    partial class LoginForm
    {
        private MaterialSkin.Controls.MaterialTextBox2 txtUsername;
        private MaterialSkin.Controls.MaterialTextBox2 txtPassword;
        private MaterialSkin.Controls.MaterialButton btnLogin;
        private MaterialSkin.Controls.MaterialButton btnRegister;
        private MaterialSkin.Controls.MaterialCheckbox chkShowPassword;
        private MaterialSkin.Controls.MaterialCheckbox chkDarkTheme;
        private System.Windows.Forms.LinkLabel linkRu;
        private System.Windows.Forms.LinkLabel linkEn;
        private System.Windows.Forms.Panel panelCard;

        private void InitializeComponent()
        {
            this.panelCard = new System.Windows.Forms.Panel();
            this.txtUsername = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtPassword = new MaterialSkin.Controls.MaterialTextBox2();
            this.chkShowPassword = new MaterialSkin.Controls.MaterialCheckbox();
            this.chkDarkTheme = new MaterialSkin.Controls.MaterialCheckbox();
            this.btnLogin = new MaterialSkin.Controls.MaterialButton();
            this.btnRegister = new MaterialSkin.Controls.MaterialButton();
            this.linkRu = new System.Windows.Forms.LinkLabel();
            this.linkEn = new System.Windows.Forms.LinkLabel();
            this.panelCard.SuspendLayout();
            this.SuspendLayout();

            // panelCard
            this.panelCard.Anchor = AnchorStyles.None;
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard.Controls.Add(this.txtUsername);
            this.panelCard.Controls.Add(this.txtPassword);
            this.panelCard.Controls.Add(this.chkShowPassword);
            this.panelCard.Controls.Add(this.chkDarkTheme);
            this.panelCard.Controls.Add(this.btnLogin);
            this.panelCard.Controls.Add(this.btnRegister);
            this.panelCard.Location = new System.Drawing.Point(50, 50);
            this.panelCard.Size = new System.Drawing.Size(600, 350);

            // txtUsername
            this.txtUsername.Hint = "";
            this.txtUsername.Location = new System.Drawing.Point(30, 20);
            this.txtUsername.Size = new System.Drawing.Size(540, 48);
            this.txtUsername.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            // txtPassword
            this.txtPassword.Hint = "";
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Location = new System.Drawing.Point(30, 80);
            this.txtPassword.Size = new System.Drawing.Size(540, 48);
            this.txtPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            // chkShowPassword
            this.chkShowPassword.Text = "";
            this.chkShowPassword.Location = new System.Drawing.Point(30, 140);
            this.chkShowPassword.Size = new System.Drawing.Size(200, 36);
            this.chkShowPassword.Anchor = AnchorStyles.Left | AnchorStyles.Top;

            // chkDarkTheme
            this.chkDarkTheme.Text = "";
            this.chkDarkTheme.Location = new System.Drawing.Point(270, 140);
            this.chkDarkTheme.Size = new System.Drawing.Size(200, 36);
            this.chkDarkTheme.Anchor = AnchorStyles.Left | AnchorStyles.Top;

            // btnLogin
            this.btnLogin.Text = "";
            this.btnLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLogin.Location = new System.Drawing.Point(200, 190);
            this.btnLogin.Size = new System.Drawing.Size(200, 40);
            this.btnLogin.UseAccentColor = true;
            this.btnLogin.Anchor = AnchorStyles.Top;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnRegister
            this.btnRegister.Text = "";
            this.btnRegister.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnRegister.Location = new System.Drawing.Point(200, 250);
            this.btnRegister.Size = new System.Drawing.Size(200, 40);
            this.btnRegister.UseAccentColor = true;
            this.btnRegister.Anchor = AnchorStyles.Top;

            // linkRu
            this.linkRu.Text = "";
            this.linkRu.Location = new System.Drawing.Point(10, 400);
            this.linkRu.Size = new System.Drawing.Size(70, 20);
            this.linkRu.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            // linkEn
            this.linkEn.Text = "";
            this.linkEn.Location = new System.Drawing.Point(700 - 70, 400);
            this.linkEn.Size = new System.Drawing.Size(70, 20);
            this.linkEn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // LoginForm
            this.ClientSize = new System.Drawing.Size(700, 430);
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.panelCard);
            this.Controls.Add(this.linkRu);
            this.Controls.Add(this.linkEn);
            this.BackColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.panelCard.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}