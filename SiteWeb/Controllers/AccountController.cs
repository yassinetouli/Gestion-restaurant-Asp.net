using Microsoft.AspNetCore.Mvc;
using SiteWeb.Data;
using SiteWeb.Models;
using SiteWeb.Services;

namespace SiteWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyDbContext _context;

        public AccountController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Show_Signup()
        {
            return View("~/Views/Account/Signup.cshtml");   
        }

        public IActionResult Show_Login()
        {
            return View("~/Views/Account/Login.cshtml");
        }

        [HttpPost]
        public IActionResult Signup(UtilisateursModel Model)
        {
            if(ModelState.IsValid)
            {
                var Signup = new SignupServices(_context);
                var user = Signup.Store(Model.Username, Model.Email, Model.Password, Model.Role);

                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("Role", user.Role);

                switch (Model.Role)
                {
                    case "Admin":
                        return RedirectToAction("Show_Admin", "Admin");
                    case "Livreur":
                        return RedirectToAction("Show_livreur", "Livreur");
                    default:
                        return RedirectToAction("Index", "Home");
                }
            } 

            return View(Model);

        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var loginService = new LoginServices(_context);
            var user = loginService.Verify_login(model.Email, model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login credentials");
                return View(model);
            }

            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Role", user.Role);

            switch (user.Role)
            {
                case "Admin":
                    return RedirectToAction("Show_Admin", "Admin");
                case "Livreur":
                    return RedirectToAction("Show_livreur", "Livreur");
                default:
                    return RedirectToAction("Index", "Home");
            }
        }


    }
}
