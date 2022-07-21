using FoodDeliveryApp.Models;
using FoodDeliveryApp.Repository;

namespace FoodDeliveryApp.Services
{
    public class UserService
    {
        private readonly IFoodRepository _foodRepository;
        public UserService(IFoodRepository foodRepository)
        {
            _foodRepository =foodRepository ;
        }

        public List<User> getUsers()
        {
            return _foodRepository.GetAllUsers();
        }
    }
}
