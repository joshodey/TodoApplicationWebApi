using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyTodo_Application.DTO;
using MyTodo_Application.Services;

namespace MyTodo_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private IConfiguration _configuration;
        private IUser _user;
        public UserLoginController(IConfiguration configuration, IUser user)
        {
            _configuration = configuration;
            _user = user;
        }
        [AllowAnonymous]
        [HttpPost]

        public IActionResult Login([FromBody] UserLogin login)
        {
            var user = Authenticate(login);
            if (user == null)
            {
                var token = Generate(user);
                return Ok(token);
            }
            return BadRequest("User Not Found");
        }

        private string Generate(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                 new Claim(ClaimTypes.GivenName, user.FirstName),
                  new Claim(ClaimTypes.Surname, user.LastName),
                  new Claim(ClaimTypes.Role, user.Role)
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel Authenticate(UserLogin login)
        {
            var currentUser = _user.GetOneUser(login.UserName);
            var password = currentUser.Password;
            if (login.UserName == currentUser.UserName && login.Password == password)
            {
                return currentUser;
            }
            return null;
        }
    }
}
