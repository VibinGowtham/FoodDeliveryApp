using FoodDeliveryApp.Models;

namespace FoodDeliveryApp.Repository
{
    public interface IFoodRepository
    {
        public List<User> GetAllUsers();
    }
}
