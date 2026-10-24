using Microsoft.AspNetCore.Mvc;
using SiteWeb.Models;
using SiteWeb.Entity;

namespace SiteWeb.Services
{
    public class LoginServices
    {
        private readonly Data.MyDbContext _context;
        public LoginServices(Data.MyDbContext context)
        {
            _context = context;
        }

        public Utilisateur Verify_login(string email, string password)
        {
            return _context.Utilisateurs
                .FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
