using FoodDeliveryApp.Models;
using FoodDeliveryApp.Repository;

namespace FoodDeliveryApp.Services
{
    public class RestaurantService
    {
        private readonly IFoodRepository _foodRepository;
        public RestaurantService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            return _foodRepository.CreateRestaurant(restaurant);
        }

        public Restaurant UpdatePrice(Restaurant restaurant)
        {
            return _foodRepository.UpdateDeliveryPrice(restaurant);
        }

        public List<Restaurant> GetRestaurantsByOwnerId(int OwnerId)
        {
            return _foodRepository.GetRestaurants(OwnerId);
        }

        public Restaurant? FindRestaurant(int id)
        {
            return _foodRepository.FindRestaurant(id);
        }

    }
}
