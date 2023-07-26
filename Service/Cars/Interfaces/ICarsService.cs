using TravelEasy.ElectricVehicles.DB.Models;

namespace Service.Cars.Interfaces
{
    public interface ICarsService
    {
        ICollection<ElectricVehicle> GetAll();
        ElectricVehicle GetByID(int CarId);
    }
}
