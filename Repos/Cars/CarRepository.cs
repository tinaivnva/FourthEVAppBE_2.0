using Repos.Cars.Interfaces;
using TravelEasy.ElectricVehicles.DB.Models;
using TravelEasy.EV.DataLayer;

namespace Repos.Cars
{
    public class CarRepository : ICarRepository
    {
        private readonly ElectricVehiclesContext _EVContext;
        public CarRepository(ElectricVehiclesContext EVContext)
        {
            _EVContext = EVContext;
        }
        public ICollection<ElectricVehicle> GetAll()
        => _EVContext.ElectricVehicles.ToList();

        public ElectricVehicle GetByID(int CarId)
        {
            throw new NotImplementedException();
        }
    }
}