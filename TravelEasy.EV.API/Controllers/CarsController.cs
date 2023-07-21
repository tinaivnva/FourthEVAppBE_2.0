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
        [HttpGet($"Car{Id}")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CarsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
