using TechZoneAdminWinFormsTest.Data.UserEntities;

namespace TechZoneAdminWinFormsTest.Services
{
    public interface IAuthService
    {
        bool Login(string username, string password);
        void Register(string username, string password, string role = "Admin");
        Admin GetCurrentAdmin(); 
    }
}