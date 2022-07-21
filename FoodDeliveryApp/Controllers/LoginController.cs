using FoodDeliveryApp.Models;
using FoodDeliveryApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Controllers
{
    [Route("user")]
    public class LoginController : Controller
    {
       private readonly UserService _userService;
       public LoginController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet("")]
        public List<User> Index()
        {
            return _userService.getUsers();
        }
    }
}
