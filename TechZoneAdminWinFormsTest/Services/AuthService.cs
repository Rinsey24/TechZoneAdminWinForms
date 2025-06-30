using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechZoneAdminWinFormsTest.Data.UserEntities;
using TechZoneAdminWinFormsTest.Data;

namespace TechZoneAdminWinFormsTest.Services
{
    public class AuthService : IAuthService
    {
        private readonly UsersContext _dbContext;
        private Admin _currentAdmin;

        public AuthService(UsersContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }


        public bool Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            try
            {
                var admin = _dbContext.Admins
                    .AsNoTracking()
                    .FirstOrDefault(a => EF.Functions.Like(a.Username, username));

                if (admin == null || !BCrypt.Net.BCrypt.Verify(password, admin.PasswordHash))
                    return false;

                _currentAdmin = admin;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Admin GetCurrentAdmin()
        {
            return _currentAdmin;
        }

        public void Register(string username, string password, string role = "Admin")
        {
            ValidateCredentials(username, password);

            if (_dbContext.Admins.Any(a => a.Username == username.Trim()))
                throw new ArgumentException("Username already exists");

            var admin = new Admin
            {
                Username = username.Trim(),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                CreatedAt = DateTime.UtcNow,
                Role = role,
                ProfileImage = "default.png"
            };

            _dbContext.Admins.Add(admin);
            _dbContext.SaveChanges();
        }

        private void ValidateCredentials(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || username.Length < 4)
                throw new ArgumentException("Username must be at least 4 characters");

            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                throw new ArgumentException("Password must be at least 8 characters");
        }
    }
}
