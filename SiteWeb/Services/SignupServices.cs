using Microsoft.EntityFrameworkCore;
using SiteWeb.Data;

namespace SiteWeb.Services
{
    public class SignupServices
    {
        private readonly MyDbContext _context;

        public SignupServices(MyDbContext context)
        {
            _context = context;
        }

        public Entity.Utilisateur Store(string Username, string Email, string Password, string Role)
        {
            try
            {
                var user = new Entity.Utilisateur
                {
                    Username = Username,
                    Email = Email,
                    Password = Password,
                    Role = Role
                };

                _context.Utilisateurs.Add(user);
                _context.SaveChanges();

                return user;
            }
            catch (DbUpdateException ex)
            {
                var error = ex.InnerException?.Message;
                throw new Exception(error);
            }
        }



    }
}
