using System.ComponentModel.DataAnnotations;

namespace SiteWeb.Models
{
    public class ProduitIndexViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(100)]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prix est obligatoire")]
        [Range(1, 100000, ErrorMessage = "Prix invalide")]
        public decimal Prix { get; set; }

        [Required(ErrorMessage = "La description est obligatoire")]
        public string Description { get; set; }

        //[Url(ErrorMessage = "URL invalide")]
        public IFormFile ImageFile { get; set; }
        public string ImageUrl { get; set; }  


    }
}
