using SiteWeb.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteWeb.Entity
{
    [Table("Commande")]

    public class Commande : Base
    {
        public Commande() { }

        [ForeignKey("clientId")]
        public Utilisateur User { get; set; }      
        
        public int produitId { get; set; }
        public int clientId { get; set; }          
        public int? livreurId { get; set; }        

        
        public decimal TotalHT { get; set; }       
        public TypeCommande Statut { get; set; }
    }

    [Table("CommandeDetail")]

    public class CommandeDetail : Base
    {
        public Commande Commande { get; set; }       
        public Produit Produit { get; set; }




        public int CommandeId { get; set; }          
        //public int ProduitId { get; set; }           
        public int UtilisateurId { get; set; }       

        
        public int Quantite { get; set; }            
        public decimal PrixUnitaire { get; set; }    
        public decimal TotalLigne { get; set; }      
        public string Adresse { get; set; }
    }

    public enum TypeCommande
    {
        EnAttente,
        Validee,
        EnLivraison,
        Livree
    }


}
