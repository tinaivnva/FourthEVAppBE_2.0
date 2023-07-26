﻿using Service.Cars.Interfaces;
using TravelEasy.ElectricVehicles.DB.Models;
using TravelEasy.EV.DataLayer;

namespace Service.Cars
{
    public class CarsService : ICarsService
    {
        private readonly ElectricVehiclesContext _EVContext;

        public CarsService(ElectricVehiclesContext EVContext)
        {
            _EVContext = EVContext;
        }
        public ICollection<ElectricVehicle> GetAll()
        {
            return _EVContext.ElectricVehicles.ToList();
        }

        ElectricVehicle ICarsService.GetByID(int CarId)
        {
            return _EVContext.ElectricVehicles.ToList()[CarId];
        }
    }
}