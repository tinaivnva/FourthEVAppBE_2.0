using Microsoft.AspNetCore.Mvc;
using TravelEasy.EV.DataLayer;
using Microsoft.EntityFrameworkCore;
using TravelEasy.ElectricVehicles.DB.Models;
using Microsoft.AspNetCore.Identity;
using TravelEasy.EV.API.Models.CarModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelEasy.EV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        
        private readonly ElectricVehiclesContext _EVContext;
        
        public CarsController(ElectricVehiclesContext EVContext)
        {
            _EVContext = EVContext;
        }
        // GET: api/<CarsController>
        [HttpGet]
        public IActionResult GetAllCars()
        {
            var list = _EVContext.ElectricVehicles;
            var allCars = new List<CarResponseModel>();
            if (allCars.Count == 0) 
            {
                return Ok("No available cars");
            }
            foreach (var car in list) 
            {
                CarResponseModel carModel = new CarResponseModel();
                carModel.Brand = car.Brand;
                carModel.Model = car.Model;
                carModel.Price = car.PricePerDay;
                allCars.Add(carModel);
            }
            
            return Ok(allCars);
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<CarDetailResponceModel> Get(int id, [System.Web.Http.FromUri] int userId)
        {
            // Check if user exists
            if (!_EVContext.Users.Where(u => u.Id == userId).Any())
            {
                return Unauthorized();
            }
            ElectricVehicle? ev = _EVContext.ElectricVehicles.Where(ev => ev.Id == id).FirstOrDefault();
            if (ev == null)
            {
                return NotFound();
            }
            CarDetailResponceModel result = new()
            {
                Brand = ev.Brand,
                Model = ev.Model,
                HorsePowers = ev.HorsePowers,
                Range = ev.Range,
                PricePerDay = ev.PricePerDay
            };
            return Ok(result);
        }
    }
}