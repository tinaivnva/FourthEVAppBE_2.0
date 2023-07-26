using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEasy.ElectricVehicles.DB.Models;

namespace Service
{
    public interface IUserService
    {
        public bool checkIfUserExists (int userId);
        public void SaveUserInDB (User user);
        public User GetUserByUsername (string username);
    }
}
