using FoodDeliveryApp.Models;
using FoodDeliveryApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Controllers
{
    [Route("user")]
    public class UserController : ControllerBase
    {
       private readonly UserService _userService;

        private readonly RestaurantService _restaurantService;
        public UserController(UserService userService, RestaurantService restaurantService)
        {
            _userService = userService;
            _restaurantService = restaurantService;
        }
        //[HttpGet("getUsers")]
        //public List<User> Index()
        //{
        //    return _userService.getUsers();
        //}

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            if (user==null || user.Email == null || user.Password == null)
            {
                return BadRequest("Enter Username and Password");
            }
            User? found = _userService.SearchUser(user.Email);
            if (found != null)
            {
              var jwt=  _userService.CreateToken(found);
                return Ok(jwt);
            }
            else
            {
                return BadRequest("User Not Found");
            }

        }

        [Authorize(Roles = "Owner")]

        [HttpGet("getRestaurants")]
        public List<Restaurant> getRestaurantsByOwner()
        {
            var email = _userService.getEmailFromToken(HttpContext);
            if (email == "")
            {
                return new List<Restaurant>();
            }
            User user = _userService.SearchUser(email);
            List<Restaurant> restaurants= _restaurantService.GetRestaurantsByOwnerId(user.UserId);
            return restaurants;
        }

        [Authorize(Roles ="Owner")]

        [HttpPost("updateDeliveryPrice")]
        public Restaurant? updateDeliveryPrice([FromBody] Restaurant restaurant)
        {
            var newPrice = restaurant.DeliveryPrice; 
            Restaurant ?found = getRestaurant(restaurant.RestaurantId);
            if (found == null || newPrice == 0)
            {
                return new Restaurant();
            }
            restaurant.DeliveryPrice = newPrice;
            return restaurant;

        }

        [Authorize(Roles = "Owner")]

        [HttpPost("getRestaurant/{restaurantId}")]
        public Restaurant? getRestaurant(int restaurantId)
        {
            return _restaurantService.FindRestaurant(restaurantId);
        }


        [HttpPost("addItem")]
        public FoodItem? AddItem([FromBody]FoodItem foodItem)
        {
            return _restaurantService.AddFoodItem(foodItem);
        }
    }
}
