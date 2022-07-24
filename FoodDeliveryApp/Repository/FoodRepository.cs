using FoodDeliveryApp.Models;

namespace FoodDeliveryApp.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly UserDBContext _dbContext;
        public FoodRepository(UserDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }
        public User? FindUser(string? Email)
        {
            return (User?)_dbContext.Users.FirstOrDefault(user => user.Email == Email);
        }

        public Restaurant CreateRestaurant(Restaurant restaurant)
        {
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();
            return restaurant;
        }

        public Restaurant UpdateDeliveryPrice(Restaurant restaurant)
        {
            _dbContext.Restaurants.Update(restaurant);
            _dbContext.SaveChanges();
            return restaurant;
        }

        public List<Restaurant> GetRestaurants(int OwnerId)
        {
            return _dbContext.Restaurants.Where(restaurant => restaurant.UserId == OwnerId).ToList();
        }


        public Restaurant? FindRestaurant(int resId)
        {
            return _dbContext.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId==resId);
        }

    }
}
