using Microsoft.AspNetCore.Mvc;
using TravelEasy.ElectricVehicles.DB.Models;
using Service.Cars;
using Service.Cars.Interfaces;
using TravelEasy.EV.API.Models.CarModels;
using Service;

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

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CarResponseModel()
        { 
            var models = new List<ElectricVehicle>();
            var vehicles = _carsService.GetAll();

            foreach (var vehicle in vehicles)
            {
                ElectricVehicle newModel = new()
                {
                    Brand = vehicle.Brand,
                    Model = vehicle.Model,
                    PricePerDay = vehicle.PricePerDay,
                    Image = vehicle.Image,
                    Category = vehicle.Category,
                };
                models.Add(newModel);
            }

            return Ok(models);
        }

        [HttpGet()]
        [Route("{CarId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult CarDetailResponce(int id, [System.Web.Http.FromUri] int CarId)
        {
            ElectricVehicle? ev = _carsService.GetByID(CarId);
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
                Category = ev.Category
            };

            return Ok(result);      
        }
    }
}