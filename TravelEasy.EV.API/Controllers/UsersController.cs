using Microsoft.AspNetCore.Mvc;
using TravelEasy.ElectricVehicles.DB.Models;
using TravelEasy.EV.API.Models.UserModels;
using Service;

namespace TravelEasy.EV.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {        
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserLoginRequestModel model)
        {
            var user = _userService.GetUserByUsername(model.Username);

            if (user == null)
            {
                return BadRequest();
            }

            if (model.Password != user.Password)
            {
                return BadRequest();
            }

            return Ok(user.Id);

        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] UserRegisterRequestModel model)
        {
            User user = new()
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password
            };

            _userService.SaveUserInDB(user);

            return Created(nameof(UsersController), user.Id);
        }
    }
}
