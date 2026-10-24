using SiteWeb.Data;
using SiteWeb.Entity;
using SiteWeb.Models;

namespace SiteWeb.Repos

{
    public class ProduitRepos
    {
        private readonly MyDbContext _context;

        public ProduitRepos(MyDbContext context)
        {
            _context = context;
        }

        public List<Produit> getAll()
        {
            return _context.Produits.ToList();
        }

        public Produit Add(Produit produit)
        {
            _context.Produits.Add(produit);
            _context.SaveChanges();
            return produit;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var produit = await _context.Produits.FindAsync(id);
            if (produit == null)
                return false;
            _context.Produits.Remove(produit);
            await _context.SaveChangesAsync();
            return true;
        }
        
        public async Task<bool> UpdateAsync(Produit produit)
        {
            var existing = await _context.Produits.FindAsync(produit.Id);
            if (existing == null)
                return false;
            _context.Entry(existing).CurrentValues.SetValues(produit);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
