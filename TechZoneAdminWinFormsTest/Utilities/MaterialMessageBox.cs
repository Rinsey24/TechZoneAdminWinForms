using MaterialSkin.Controls;
using System.Windows.Forms;
using TechZoneAdminWinFormsTest.Properties;

namespace TechZoneAdminWinFormsTest.Utilities
{
    public static class MaterialMessageBox
    {
        public static void ShowInfo(string? message)
        {
            string displayMessage = string.IsNullOrWhiteSpace(message) ? Resources.DefaultInfoMessage : message;
            string title = Resources.MessageBoxInfoTitle ?? "Info";
            MessageBox.Show(displayMessage, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowError(string? message)
        {
            string displayMessage = string.IsNullOrWhiteSpace(message) ? Resources.DefaultErrorMessage : message;
            string title = Resources.MessageBoxErrorTitle ?? "Error";
            MessageBox.Show(displayMessage, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}