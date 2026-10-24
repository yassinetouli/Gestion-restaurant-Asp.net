using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteWeb.Data;
using SiteWeb.Models;
using System;
using System.Diagnostics;

namespace SiteWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _context;

        public HomeController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var produit = _context.Produits.Select(
                p => new ProduitIndexViewModel
                {
                    Id = p.Id,
                    Nom = p.Nom,
                    Prix = p.Prix,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl
                }).ToList();

            return View(produit);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
