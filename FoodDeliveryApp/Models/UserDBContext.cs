using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryApp.Models
{
    public class UserDBContext:DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<FoodItem> FoodItems { get; set; }
    }
}
