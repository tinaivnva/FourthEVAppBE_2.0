using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TravelEasy.ElectricVehicles.DB.Models;
using TravelEasy.EV.API.Models.CarModels;
using TravelEasy.EV.DataLayer;

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
    }
}
