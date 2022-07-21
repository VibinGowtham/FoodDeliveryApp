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
    }
}
