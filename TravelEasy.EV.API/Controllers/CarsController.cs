using Microsoft.AspNetCore.Mvc;
using TravelEasy.EV.DataLayer;
using Microsoft.EntityFrameworkCore;
using TravelEasy.ElectricVehicles.DB.Models;
using Microsoft.AspNetCore.Identity;
using TravelEasy.EV.API.Models.CarModels;
using System.Drawing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelEasy.EV.API.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ElectricVehiclesContext _EVContext;
        
        public CarsController(ElectricVehiclesContext EVContext)
        {
            _EVContext = EVContext;
        }

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
            ElectricVehicle? ev = _EVContext.ElectricVehicles.Where(ev => ev.CarId == id).FirstOrDefault();
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
                PricePerDay = ev.PricePerDay,
                Image = ev.Image,
                Category = ev.Category
            };
            return Ok(result);
        } 

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<ICollection<CarResponseModel>> GetAll([System.Web.Http.FromUri] int userId)
        {
            var vehicles = _EVContext.ElectricVehicles;
            // Check if user exists
            if (!_EVContext.Users.Where(u => u.Id == userId).Any())
            {
                return Unauthorized();
            }
            
            ICollection<CarResponseModel> models = new List<CarResponseModel>();
            foreach (var vehicle in vehicles)
            {
                CarResponseModel newModel = new()
                {
                    Brand = vehicle.Brand,
                    Model = vehicle.Model,
                    Price = vehicle.PricePerDay,
                    Image = vehicle.Image,
                    Category = vehicle.Category
                };
                models.Add(newModel);
            }
            return Ok(models);
        }
    }
}