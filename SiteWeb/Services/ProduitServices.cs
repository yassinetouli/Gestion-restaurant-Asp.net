using SiteWeb.Data;
using SiteWeb.Entity;
using SiteWeb.Models;
using SiteWeb.Repos;

namespace SiteWeb.Services
{
    public class ProduitServices
    {
        private readonly ProduitRepos _ProduitRepos;
        private readonly MyDbContext _context;

        public ProduitServices(MyDbContext context, ProduitRepos produitRepos)
        {
            _context = context;
            _ProduitRepos = produitRepos;
        }
       
        public List<ProduitIndexViewModel> liste_produit()

        {
            var produits = _ProduitRepos.getAll();
            

            return produits.Select(p => new ProduitIndexViewModel
            {
                Id = p.Id,
                Nom = p.Nom,
                Description = p.Description,
                Prix = p.Prix,
                ImageUrl = p.ImageUrl
            }).ToList();
        }

        public void Edit(ProduitIndexViewModel produit)
        {
            var produits = _context.Produits.Find(produit.Id);
            if (produits != null)
            {
                produits.Nom = produit.Nom;
                produits.Description = produit.Description;
                produits.Prix = produit.Prix;
                produits.ImageUrl = produit.ImageUrl;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var produit = _context.Produits.Find(id);
            if (produit != null)
            {
                _context.Produits.Remove(produit);
                _context.SaveChanges();
            }
        }

        public void Add(ProduitIndexViewModel p)
        {
            var produit = new Produit
            {
                Nom = p.Nom,
                Prix = p.Prix,
                Description = p.Description,
                ImageUrl = p.ImageUrl
            };

            _context.Produits.Add(produit);
            _context.SaveChanges();
        }

        public ProduitIndexViewModel GetById(int id)
        {
            var p = _context.Produits.Find(id);

            if (p == null) return null;

            return new ProduitIndexViewModel
            {
                Id = p.Id,
                Nom = p.Nom,
                Description = p.Description,
                Prix = p.Prix,
                ImageUrl = p.ImageUrl
            };
        }

    }
}
