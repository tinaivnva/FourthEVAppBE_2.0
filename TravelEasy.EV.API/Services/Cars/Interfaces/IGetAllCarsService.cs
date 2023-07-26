using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEasy.ElectricVehicles.DB.Models;

namespace Service.Cars.Interfaces
{
    public interface IGetAllCarsService
    {
        public void GetAll(List<ElectricVehicle> electricVehicles);
    }
}
