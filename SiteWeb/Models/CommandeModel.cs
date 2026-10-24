using SiteWeb.Entity;
using System.ComponentModel.DataAnnotations;

namespace SiteWeb.Models
{
    public class CommandeModel
    {
        public int ProduitId { get; set; }
        public int Quantite { get; set; }
        public int ClientId { get; set; }
        public string Adresse { get; set; }
    }


    public class CommandeDetailModel
    {
        public int CommandeId { get; set; }        
        public string Username { get; set; }       
        public string? Adresse { get; set; }       
        public int ProduitId { get; set; }         
        public string ProduitNom { get; set; }     
        public int Quantite { get; set; }          
        public decimal PrixUnitaire { get; set; }  
        public decimal TotalLigne { get; set; }    
        public TypeCommande Statut { get; set; }   
    }
}
