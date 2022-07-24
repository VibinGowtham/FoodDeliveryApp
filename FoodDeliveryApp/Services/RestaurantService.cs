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

        public FoodItem? AddFoodItem(FoodItem foodItem)
        {
            return _foodRepository.AddFoodItem(foodItem);
        }

        public List<FoodItem> GetFoodItemsById(int restaurantId)
        {
            return _foodRepository.GetAllFoodItemsById(restaurantId);
        }

        public FoodItem GetItem(FoodItem foodItem)
        {
            return _foodRepository.GetFoodItem(foodItem);  
        }
        public FoodItem? UpdateItem(FoodItem foodItem)
        {
            if (foodItem.Availability.ToLower() == "yes")
            {
                foodItem.Availability = "No";
            }
            else foodItem.Availability = "Yes";
            return _foodRepository.UpdateAvailablity(foodItem);
        }

        public Boolean DeleteItem(FoodItem foodItem)
        {
            return _foodRepository.DeleteItem(foodItem);
        }



    }
}
