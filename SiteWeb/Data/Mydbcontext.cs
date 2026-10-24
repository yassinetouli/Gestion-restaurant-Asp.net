using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SiteWeb.Entity;

namespace SiteWeb.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        
        public DbSet<CommandeDetail> CommandeDetails { get; set; }
        public DbSet<Produit> Produits { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Produit>().HasData(
        //        new Produit
        //        {
        //            Id = 1,
        //            Nom = "Produit A",
        //            Description = "Description du Produit A",
        //            Prix = 10.99f,
        //            ImageUrl = "https://example.com/imageA.jpg"
        //        },
        //        new Produit
        //        {
        //            Id = 2,
        //            Nom = "Produit B",
        //            Description = "Description du Produit B",
        //            Prix = 15.49f,
        //            ImageUrl = "https://example.com/imageB.jpg"
        //        },
        //        new Produit
        //        {
        //            Id = 3,
        //            Nom = "Produit C",
        //            Description = "Description du Produit C",
        //            Prix = 7.99f,
        //            ImageUrl = "https://example.com/imageC.jpg"
        //        }
        //    );
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilisateur>().HasData(
                new Utilisateur
                {
                    Id = 10,
                    Username = "Admin",
                    Email = "Admin@gmail.com",
                    Password = "Admin123",
                    Role = "Admin"
                }
                );



        }
    }
}
