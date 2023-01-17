using Microsoft.AspNetCore.Mvc;
using MyTodo_Application.DTO;
using MyTodo_Application.Services;

namespace MyTodo_Application.Controllers
{
    public class RegisterUserController : Controller
    {
        private IUser _user;
        public RegisterUserController(IUser user)
        {
            _user = user;
        }

        [HttpPost("RegisterNewUser")]
        public IActionResult RegisterNewUser([FromQuery] RegisterUser user)
        {
            var newuser = _user.AddUser(user);
            if (newuser != null)
            {
                return Ok(newuser);
            }
            return BadRequest("UserName already exist");
        }
    }
}
