using Microsoft.AspNetCore.Mvc;
using SiteWeb.Services;
using SiteWeb.Entity;

namespace SiteWeb.Services

{
    public class CommandeServices
    {
        private readonly Data.MyDbContext _context;
        public CommandeServices(Data.MyDbContext context)
        {
            _context = context;
        }

        public bool Create_Commande(int produitId, int quantite, string adresse, int clientId)
{
    try
    {
        var client = _context.Utilisateurs.FirstOrDefault(u => u.Id == clientId);
        if (client == null) return false;

        var produit = _context.Produits.FirstOrDefault(p => p.Id == produitId);
        if (produit == null) return false;

        decimal totalHT = produit.Prix * quantite;

        var commande = new Commande
        {
            clientId = client.Id,
            produitId = produitId,  // ← AJOUTER CETTE LIGNE
            User = client,
            TotalHT = totalHT,
            Statut = TypeCommande.EnAttente
        };

        _context.Commandes.Add(commande);
        _context.SaveChanges();

        var detail = new CommandeDetail
        {
            CommandeId = commande.Id,
            UtilisateurId = client.Id,
            Quantite = quantite,
            PrixUnitaire = produit.Prix,
            TotalLigne = totalHT,
            Adresse = adresse,
            Produit = produit,
        };

        _context.CommandeDetails.Add(detail);
        _context.SaveChanges();
        
        return true;
    }
    catch (Exception ex)
    {
        // Log l'erreur ici si vous avez un logger
        // _logger.LogError(ex, "Erreur lors de la création de la commande");
        return false;
    }
}
}
}