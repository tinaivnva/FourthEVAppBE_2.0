using Microsoft.AspNetCore.Mvc;
using TravelEasy.ElectricVehicles.DB.Models;
using Service.Cars;
using TravelEasy.EV.API.Models.CarModels;
using Service.user;
using TravelEasy.EV.Services.Cars;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelEasy.EV.API.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarsService _carsService;
        private readonly IUserService _userService;

        public CarsController(IUserService userService,ICarsService carsService)
        {
            _userService = userService;
            _carsService = carsService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CarResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CarResponseModel(int userId)
        {
            if (!_userService.checkIfUserExists(userId))
            {
                return Unauthorized();
            }

            var models = new List<CarResponseModel>();
            var vehicles = _carsService.GetAll();

            foreach (var vehicle in vehicles)
            {
                CarResponseModel newModel = new()
                {
                    Brand = vehicle.Brand,
                    Model = vehicle.Model,
                    Image = vehicle.Image,
                    Category =vehicle.Category.CategoryName,
                    Price = vehicle.PricePerDay
                };
                models.Add(newModel);
            }

            return Ok(models);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult CarDetailResponce(int id, [System.Web.Http.FromUri] int userId)
        {
            if (!_userService.checkIfUserExists(userId))
            {
                return Unauthorized();
            }

            ElectricVehicle? ev = _carsService.GetByID(id);

            if (ev == null)
            {
                return NotFound();
            }

            CarDetailResponseModel result = new()
            {
                Brand = ev.Brand,
                Model = ev.Model,
                HorsePowers = ev.HorsePowers,
                Range = ev.Range,
                PricePerDay = ev.PricePerDay,
                Image = ev.Image,
                CategoryId = ev.CategoryId
            };

            return Ok(result);      
        }
    }
}