using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDeliveryApp.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
        public string OwnerName { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User user { get; set; }

        public string RestaurantName { get; set; }

        public int DeliveryPrice { get; set; }

    }
}
