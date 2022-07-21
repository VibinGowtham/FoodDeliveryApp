using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50),EmailAddress]
        public string Email { get; set; } = string.Empty;

        [StringLength(30)]
        public string Password { get; set; } = string.Empty;

        public Boolean Admin { get; set; }
    }
}
