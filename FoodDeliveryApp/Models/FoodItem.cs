using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDeliveryApp.Models
{
    public class FoodItem
    {

        [Key]
        public int ItemId { get; set; }
        public int RestaurantId { get; set; }

        [ForeignKey("RestaurantId")]
        public virtual Restaurant restaurant { get; set; }
        
        public string ItemName { get; set; }

        public int Price { get; set; } = 200;

        public string Availability { get; set; } = "Yes";


    }
}
