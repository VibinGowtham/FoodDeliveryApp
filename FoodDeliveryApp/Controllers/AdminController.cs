using FoodDeliveryApp.Models;
using FoodDeliveryApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Controllers
{
    [Authorize(Roles= "Admin")]
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly UserService _userService;
        private readonly RestaurantService _restaurantService;
        public AdminController(UserService userService,RestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
            _userService = userService;
        }

        [HttpPost("addRestaurant")]
        public Restaurant addRestaurant([FromBody]Restaurant restaurant)
        {
           
            var email = restaurant.OwnerName + "@gmail.com";
            var password = restaurant.OwnerName;

            var found = _userService.SearchUser(email);
            int userId;
            if (found == null)
            {
                var owner = new User();
                owner.Email = email;
                owner.Password = password;
                _userService.AddUser(owner);
                userId = owner.UserId;
            }
            else
            {
                userId=found.UserId;
            }

            restaurant.UserId = userId;
            _restaurantService.AddRestaurant(restaurant);
            return restaurant;
        }


        [HttpPost("addUser")]
        public async Task<IActionResult> Add([FromBody] User user)
        {
            if (user.Email == null || user.Password == null )
            {
                return BadRequest("User cannot be null/empty");
            }
            var email = user.Email;
            User? result = _userService.SearchUser(email);
            if (result != null)
            {
                return BadRequest("User Already Exists");
            }
            else
            {
                _userService.AddUser(user);
                return Ok(user);
            }

        }
    }
}
