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
                bool verified = BCrypt.Net.BCrypt.Verify(user.Password, found.Password);
                if (verified)
                {
                    var jwt = _userService.CreateToken(found);
                    return Ok(jwt);
                }
                
            }
          
                return BadRequest("User Not Found");
            

        }


        [HttpGet("getRestaurants"), Authorize(Roles = "Owner")]
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


        [HttpPost("updateDeliveryPrice"), Authorize(Roles = "Owner")]
        public Restaurant? updateDeliveryPrice([FromBody] Restaurant restaurant)
        {
            var newPrice = restaurant.DeliveryPrice; 
            Restaurant ?found = getRestaurant(restaurant.RestaurantId);
            if (found == null || newPrice == 0)
            {
                return new Restaurant();
            }
            found.DeliveryPrice = newPrice;
            _restaurantService.UpdatePrice(found);
            return found;

        }


        [HttpGet("getRestaurant/{restaurantId}"), Authorize(Roles = "Owner")]
        public Restaurant? getRestaurant(int restaurantId)
        {
            return _restaurantService.FindRestaurant(restaurantId);
        }


        [HttpPost("addItem"),Authorize(Roles ="Owner")]
        public FoodItem? AddItem([FromBody]FoodItem foodItem)
        {
            return _restaurantService.AddFoodItem(foodItem);
        }

        [HttpGet("getAllItems/{restaurantId}"), Authorize(Roles = "Owner")]
        public List<FoodItem> getAllItems(int restaurantId)
        {
            return _restaurantService.GetFoodItemsById(restaurantId);
        }

        [HttpPost("updateItem"), Authorize(Roles = "Owner")]
        public FoodItem? UpdateAvailabity([FromBody]FoodItem foodItem)
        {
            FoodItem instance = _restaurantService.GetItem(foodItem);
            _restaurantService.UpdateItem(instance);
            return instance;
        }

        [HttpPost("deleteItem"), Authorize(Roles = "Owner")]
        public String deleteItem([FromBody] FoodItem foodItem)
        {
            FoodItem instance = _restaurantService.GetItem(foodItem);
            if (_restaurantService.DeleteItem(instance)) return "Item Sucecessfully deleted";
            else return "Item Does'nt Exists";
        }

    }
}
