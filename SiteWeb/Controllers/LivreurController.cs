using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteWeb.Models;
using SiteWeb.Entity;

namespace SiteWeb.Controllers
{
    public class LivreurController : Controller
    {
        private readonly Data.MyDbContext _context;
        public LivreurController(Data.MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Show_livreur()
        {
            var commandes = _context.CommandeDetails
                .Include(cd => cd.Commande)
                .ThenInclude(c => c.User)
                .Select(cd => new CommandeDetailModel
                {
                    CommandeId = cd.Commande.Id,
                    ProduitNom = cd.Produit.Nom,
                    Username = cd.Commande.User.Username,
                    Adresse = cd.Adresse,
                    Quantite = cd.Quantite,
                    PrixUnitaire = cd.PrixUnitaire,
                    TotalLigne = cd.TotalLigne,
                    Statut = cd.Commande.Statut
                }).ToList();


            return View("~/Views/Livreur/LivreurIndex.cshtml",commandes);
        }

        [HttpPost]
        public IActionResult AcceptCommande(int commandeId)
        {
            var livreurId = HttpContext.Session.GetInt32("UserId");
            if (livreurId == null)
            {
                return RedirectToAction("Show_Login", "Account");
            }

            var commande = _context.Commandes.FirstOrDefault(c => c.Id == commandeId);
            if (commande == null)
            {
                TempData["Error"] = "Commande introuvable";
                return RedirectToAction("Show_livreur");
            }

            if (commande.Statut != TypeCommande.EnAttente)
            {
                TempData["Error"] = "Cette commande n'est plus en attente";
                return RedirectToAction("Show_livreur");
            }

            commande.Statut = TypeCommande.EnLivraison;
            commande.livreurId = livreurId.Value;

            _context.Commandes.Update(commande);
            _context.SaveChanges();

            TempData["Success"] = "Commande acceptée avec succès";
            return RedirectToAction("Show_livreur");
        }

        [HttpPost]
        public IActionResult MarquerLivree(int commandeId)
        {
            var livreurId = HttpContext.Session.GetInt32("UserId");
            if (livreurId == null)
            {
                return RedirectToAction("Show_Login", "Account");
            }

            var commande = _context.Commandes.FirstOrDefault(c => c.Id == commandeId);
            if (commande == null)
            {
                TempData["Error"] = "Commande introuvable";
                return RedirectToAction("Show_livreur");
            }

            if (commande.Statut != TypeCommande.EnLivraison)
            {
                TempData["Error"] = "Cette commande n'est pas en livraison";
                return RedirectToAction("Show_livreur");
            }

            if (commande.livreurId != livreurId.Value)
            {
                TempData["Error"] = "Vous n'êtes pas autorisé à modifier cette commande";
                return RedirectToAction("Show_livreur");
            }

            commande.Statut = TypeCommande.Livree;

            _context.Commandes.Update(commande);
            _context.SaveChanges();

            TempData["Success"] = "Commande marquée comme livrée";
            return RedirectToAction("Show_livreur");
        }
    }
}

