using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEasy.ElectricVehicles.DB.Models;

namespace Repos.Cars.Interfaces
{
    public interface ICarRepository
    {
        ICollection<ElectricVehicle> GetAll();
        ElectricVehicle GetByID(int CarId);
    }
}
