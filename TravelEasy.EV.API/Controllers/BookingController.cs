using Microsoft.AspNetCore.Mvc;
using Service.CarBooking;
using Service.user;
using TravelEasy.ElectricVehicles.DB.Models;
using TravelEasy.EV.API.Models.BookingModels;
using TravelEasy.EV.API.Models.CarModels;
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
        [HttpPost("book-a-car")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult AddBooking([FromBody] BookingRequestModel request) // to fix
        {
            if (!_userService.checkIfUserExists(request.UserId))
            {
                return Unauthorized("User does not exists!");
            }

            ElectricVehicle? ev = _carsService.GetByID(request.CarId);

            if (ev == null)
            {
                return NotFound();
            }

            BookedCar bookedCar = new()
            {
                CarId = request.CarId,
                UsertId = request.UserId,
                FromDate = request.FromDate,
                ToDate = request.ToDate
            };
            _bookingService.AddBooking(bookedCar);

            BookingResponseModel model = new()
            {
                SuccessfullyBooked = true
            };
            return Ok(model);
        }

        [HttpGet("{CarId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<BookedCar> Get(int carId)
        {
            BookedCar? bookedCar = _bookingService.GetBookingByCarID(carId);
            if (bookedCar == null)
            {
                return BadRequest("Car is nor booked!");
            }
            return Ok(bookedCar);
        }

        [HttpGet("user-booked-cars")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<ICollection<ElectricVehicle>> GetBookedVehicles(int userId)
        {
            if (!_userService.checkIfUserExists(userId))
            {
                return Unauthorized("User does not exists!");
            }
            var userBookings = _bookingService.GetUserBookings(userId);
            if(!userBookings.Any()) 
            {
                return NotFound("User hasn't booked any cars!");  
            }
            ICollection<CarResponseModel> models = new List<CarResponseModel>();
            foreach (var bookedCars in userBookings) 
            {
                ElectricVehicle? car = _carsService.GetByID(bookedCars.CarId);
                CarResponseModel model = new()
                {
                    Brand = car.Brand,
                    Model = car.Model,
                    Price = car.PricePerDay
                };
                models.Add(model);
            }
            return Ok(models);
        }
    }
}
