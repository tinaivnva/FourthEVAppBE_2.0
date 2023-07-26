using Microsoft.AspNetCore.Mvc;
using TravelEasy.ElectricVehicles.DB.Models;
using TravelEasy.EV.API.Models.BookingModels;
using TravelEasy.EV.API.Models.UserModels;
using TravelEasy.EV.DataLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelEasy.EV.API.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ElectricVehiclesContext _EVContext;
        public BookingController(ElectricVehiclesContext EVContext)
        {
            _EVContext = EVContext;
        }
        //users booked cars
        [HttpPut("book-a-car")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Booking([FromBody] BookingRequestModel model)
        {
            if (!_EVContext.Users.Where(u => u.Id == userId).Any())
            {
                return Unauthorized();
            }
        }
        //check if user & car exist; 
        //
        /* [HttpPut("book-a-car")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status404NotFound)]
         [ProducesResponseType(StatusCodes.Status401Unauthorized)]
         public IActionResult Booking([FromBody] BookingRequestModel model)
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

         }*/

    }
}
