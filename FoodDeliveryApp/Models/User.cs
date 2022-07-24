using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(50),EmailAddress]
        public string? Email { get; set; }

        [StringLength(30)]
        public string? Password { get; set; }

        [StringLength(20)]
        public string? Role { get; set; } = "Owner";

      //public User(int userId, string? email, string? password, string? role)
      //  {
      //      UserId = userId;
      //      Email = email;
      //      Password = password;
      //      Role = role;
      //  }
    }
}
