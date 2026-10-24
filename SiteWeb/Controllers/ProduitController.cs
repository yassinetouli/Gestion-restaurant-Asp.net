using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteWeb.Data;
using SiteWeb.Models;
using SiteWeb.Repos;
using SiteWeb.Services;


namespace SiteWeb.Controllers
{
    public class ProduitController : Controller
    {
        private readonly MyDbContext _context ;
        private readonly ProduitRepos _ProduitRepos;

        public ProduitController(MyDbContext context, ProduitRepos produitRepos)
        {
            _context = context;
            _ProduitRepos = produitRepos;
        }


        [HttpPost]
        public IActionResult Edit(ProduitIndexViewModel Model)
        {
            var _produitService = new ProduitServices(_context, _ProduitRepos);
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Show_Admin");
            }
                _produitService.Edit(Model);
            return RedirectToAction("Show_Admin", "Admin");

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var del_produit = new ProduitServices(_context, _ProduitRepos);
            del_produit.Delete(id);

            return RedirectToAction("Show_Admin", "Admin");

        }

        [HttpPost]
        public IActionResult Add(ProduitIndexViewModel p)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Show_Admin", "Admin");
            }

            var produitService = new ProduitServices(_context, _ProduitRepos);
            produitService.Add(p);

            return RedirectToAction("Show_Admin", "Admin");
        }

    }
}


       


        
