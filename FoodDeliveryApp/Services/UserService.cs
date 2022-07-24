using FoodDeliveryApp.Models;
using FoodDeliveryApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FoodDeliveryApp.Services
{
    public class UserService
    {
        private readonly IConfiguration _configuration;

        private readonly IFoodRepository _foodRepository;
        public UserService(IFoodRepository foodRepository, IConfiguration configuration)
        {
            _foodRepository = foodRepository;
            _configuration = configuration;
        }


        public List<User> getUsers()
        {
            return _foodRepository.GetAllUsers();
        }

        public User AddUser(User user)
        {
            return _foodRepository.CreateUser(user);
        }

        public User? SearchUser(string Email)
        {
            return _foodRepository.FindUser(Email);
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("JWT:Secret").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public string getEmailFromToken(HttpContext httpContext)
        {
            var principal = httpContext.User;

            if (principal?.Claims != null)
            {
                foreach (var claim in principal.Claims)
                {
                    return claim.Value;
                }

            }

            return "";
        }
    }
}
