using Microsoft.EntityFrameworkCore;
using SiteWeb.Data; 
using SiteWeb.Entity;
using SiteWeb.Models;

namespace SiteWeb.Repos;

public class CommandeRepos
{
    private readonly MyDbContext _context;

    public CommandeRepos(MyDbContext context)
    {
        _context = context;
    }

    public Commande Add(Commande commande)
    {
        _context.Commandes.Add(commande);
        _context.SaveChanges();
        return commande;
    }

    public Commande? Get(int id)
    {
        return _context.Commandes.Find(id);
    }

    public List<Commande> GetAll()
    {
        return _context.Commandes.ToList();
    }

    public async Task<bool> UpdateAsync(Commande commande)
    {
        var existing = await _context.Commandes.FindAsync(commande.Id);
        if (existing == null)
            return false;

        _context.Entry(existing).CurrentValues.SetValues(commande);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var commande = await _context.Commandes.FindAsync(id);
        if (commande == null)
            return false;

        _context.Commandes.Remove(commande);
        await _context.SaveChangesAsync();
        return true;
    }

    
}
