using Microsoft.AspNetCore.Mvc;
using SiteWeb.Entity;
using SiteWeb.Services;
using SiteWeb.Models;

namespace SiteWeb.Controllers
{
    public class CommandeController: Controller
    {
        private readonly Data.MyDbContext _context;
        public CommandeController(Data.MyDbContext context)
        {
            _context = context;
        }



       [HttpPost]
public IActionResult Create(CommandeModel model)
{
    if (!ModelState.IsValid)
        return RedirectToAction("Index", "Home");

    var clientId = HttpContext.Session.GetInt32("UserId");
    if (clientId == null)
        return RedirectToAction("Show_Login", "Account");

    var service = new CommandeServices(_context);
    bool success = service.Create_Commande(model.ProduitId, model.Quantite, model.Adresse, clientId.Value);
    
    if (!success)
    {
        TempData["Error"] = "Erreur lors de la création de la commande";
    }
    
    return RedirectToAction("Index", "Home");
}
    }
}
