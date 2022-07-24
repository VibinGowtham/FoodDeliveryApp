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

        public FoodItem AddFoodItem(FoodItem foodItem)
        {
            _dbContext.FoodItems.Add(foodItem);
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return new FoodItem();
            }
            return foodItem;
        }

        public List<FoodItem> GetAllFoodItemsById(int restaurantId)
        {
            return (List<FoodItem>)_dbContext.FoodItems.Where(foodItem=>foodItem.RestaurantId==restaurantId).ToList();
        }

        public FoodItem? UpdateAvailablity(FoodItem foodItem)
        {
            _dbContext.FoodItems.Update(foodItem);
            _dbContext.SaveChanges();

            try
            {
            }
            catch (Exception)
            {
                return new FoodItem();
            }
            
            return foodItem;
        }

        public Boolean DeleteItem(FoodItem foodItem)
        {
            try
            {
                _dbContext.FoodItems.Remove(foodItem);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public FoodItem GetFoodItem(FoodItem foodItem)
        {
            FoodItem output = new FoodItem();
            List<FoodItem> foodItems=_dbContext.FoodItems.Where(item => item.RestaurantId == foodItem.RestaurantId).ToList();
            foodItems.ForEach(item =>
            {
                if (item.ItemId == foodItem.ItemId) output= item;
            });
            return output;
        }
    }
}
