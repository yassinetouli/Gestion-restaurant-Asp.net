using Microsoft.AspNetCore.Mvc;
using SiteWeb.Entity;
using SiteWeb.Models;
using SiteWeb.Services;

namespace SiteWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly ProduitServices _produitService;

        public AdminController(ProduitServices produitService)
        {
            _produitService = produitService;
        }

        public IActionResult Show_Admin()
        {
            var produits = _produitService.liste_produit();
            return View("~/Views/Admin/AdminIndex.cshtml", produits);
        }


        [HttpPost]
        public IActionResult Create(ProduitIndexViewModel model)
        {
            if (model.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image obligatoire");
            }

            string imagePath = null;

            if (model.ImageFile != null)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(model.ImageFile.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(),
                                        "wwwroot/images",
                                        fileName);

                using var stream = new FileStream(path, FileMode.Create);
                model.ImageFile.CopyTo(stream);

                imagePath = "/images/" + fileName;
            }

            model.ImageUrl = imagePath;

            _produitService.Add(model);
            return RedirectToAction("Show_Admin");
        }


        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    var produit = _produitService.GetById(id);
        //    if (produit == null) return NotFound();

        //    return View(produit);
        //}

        [HttpPost]
        public IActionResult Edit(ProduitIndexViewModel model)
        {
            var oldProduit = _produitService.GetById(model.Id);
            if (oldProduit == null) return NotFound();

            string imagePath = oldProduit.ImageUrl; 

            if (model.ImageFile != null)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(model.ImageFile.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(),
                                        "wwwroot/images",
                                        fileName);

                using var stream = new FileStream(path, FileMode.Create);
                model.ImageFile.CopyTo(stream);

                imagePath = "/images/" + fileName;
            }

            model.ImageUrl = imagePath;

            _produitService.Edit(model);
            return RedirectToAction("Show_Admin");
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            _produitService.Delete(id);
            return RedirectToAction("Show_Admin");
        }
    }
}
