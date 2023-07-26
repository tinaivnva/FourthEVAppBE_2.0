using Microsoft.AspNetCore.Mvc;
using Service.Cars.Interfaces;
using TravelEasy.ElectricVehicles.DB.Models;
using TravelEasy.EV.DataLayer;

namespace Service.Cars
{
    public class GetAllCarsService : IGetAllCarsService
    {
        private readonly ElectricVehiclesContext _EVContext;

        public GetAllCarsService(ElectricVehiclesContext EVContext)
        {
            _EVContext = EVContext;
        }
        // Check if user exists

        public void GetAll(List<ElectricVehicle> electricVehicles)
        {
            var vehicles = _EVContext.ElectricVehicles;
            List<ElectricVehicle> models = new List<ElectricVehicle>();
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
        }
    }
}