using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelEasy.ElectricVehicles.DB.Models;
using TravelEasy.EV.DataLayer;
using Microsoft.AspNetCore.Identity;
using TravelEasy.EV.API.Models.UserModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelEasy.EV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ElectricVehiclesContext _EVContext;
        public UsersController(ElectricVehiclesContext EVContext)
        {
            _EVContext = EVContext;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequestModel model)
        {
            var user = _EVContext.Users.FirstOrDefault(u => u.Username == model.Username);
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
        // PUT api/<UsersController>/5
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterRequestModel model)
        {
            User user = new();
            user.Username = model.Username;
            user.Email = model.Email;
            user.Password = model.Password;
            _EVContext.Users.Add(user);
            _EVContext.SaveChanges();
            return Created(nameof(UsersController), user.Id);
        }
        //public IActionResult Delete(int id)
        //{
        //    var user = _EVContext.Users.Find(id);
        //    _EVContext.Users.Remove(user);
        //    return Ok();
        //}
    }
}
