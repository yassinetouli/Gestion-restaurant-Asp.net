using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteWeb.Entity
{
    [Table("Utilisateur")]

    public class Utilisateur : Base
    {

        [Required(ErrorMessage = "Full Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }

        public string? Adresse { get; set; }

        [Required(ErrorMessage = "Please select a role")]
        public string Role { get; set; }

    }
}
