using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteWeb.Entity
{
    public class Produit: Base
    {
        [Required]
        public string? Nom { get; set; }
        public string? Description { get; set; }
        public decimal Prix { get; set; }
        public string ImageUrl { get; set; }
    }
}
