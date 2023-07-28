using TravelEasy.ElectricVehicles.DB.Models;

namespace TravelEasy.EV.Services.Cars
{
    public interface ICarsService
    {
        public ICollection<ElectricVehicle> GetAll();
        public ElectricVehicle GetByID(int CarId);
    }
}
