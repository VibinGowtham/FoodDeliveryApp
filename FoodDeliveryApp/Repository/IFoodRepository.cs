using FoodDeliveryApp.Models;

namespace FoodDeliveryApp.Repository
{
    public interface IFoodRepository
    {
        public List<User> GetAllUsers();

        public User CreateUser(User user);

        public User? FindUser(string Email);

        public Restaurant CreateRestaurant(Restaurant restaurant);

        public Restaurant UpdateDeliveryPrice(Restaurant restaurant);

        public List<Restaurant> GetRestaurants(int OwnerId);

        public Restaurant? FindRestaurant(int OwnerId);
    }
}
