using System;
using System.Windows.Forms;
using TechZoneAdminWinFormsTest.Data;
using TechZoneAdminWinFormsTest.Services;
using TechZoneAdminWinFormsTest.Forms;
using TechZoneAdminWinFormsTest.Data.UserEntities;

namespace TechZoneAdminWinFormsTest
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var dbContext = new UsersContext();
            var authService = new AuthService(dbContext);

            Application.Run(new LoginForm(authService));
        }
    }
}