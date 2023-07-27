using Microsoft.AspNetCore.Mvc;
using Service.CarBooking;
using Service.user;
using TravelEasy.ElectricVehicles.DB.Models;
using TravelEasy.EV.API.Models.BookingModels;
using TravelEasy.EV.Services.Cars;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelEasy.EV.API.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IBookingService _bookingService; 
        private readonly ICarsService _carsService;
        public BookingController(IBookingService bookingService, IUserService userService, ICarsService carsService)
        {
           _bookingService = bookingService;
            _carsService = carsService; 
            _userService = userService;
        }
        
        //users booked cars
        [HttpPut("book-a-car")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult AddBooking([FromBody] BookingRequestModel model) // to fix
        {
            if (!_userService.checkIfUserExists(model.UserId))
            {
                return Unauthorized();
            }

            ElectricVehicle? ev = _carsService.GetByID(model.CarId);

            if (ev == null)
            {
                return NotFound();
            }
            throw new Exception();


        }
    }
}
