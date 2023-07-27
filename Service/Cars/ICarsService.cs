using TravelEasy.ElectricVehicles.DB.Models;

namespace TravelEasy.EV.Services.Cars
{
    public interface ICarsService
    {
        ICollection<ElectricVehicle> GetAll();
        ElectricVehicle GetByID(int CarId);
    }
}
