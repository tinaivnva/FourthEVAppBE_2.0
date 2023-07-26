using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEasy.ElectricVehicles.DB.Models;
using TravelEasy.EV.DataLayer;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly ElectricVehiclesContext _EVContext;
        public UserService(ElectricVehiclesContext EVContext)
        {
            _EVContext = EVContext;
        }

        public bool checkIfUserExists(int userId)
        {
            return _EVContext.Users.Where(u => u.Id == userId).Any();
        }

        public User GetUserByUsername(string username)
        {
            return _EVContext.Users.FirstOrDefault(u => u.Username == username);
        }

        public void SaveUserInDB(User user)
        {
            _EVContext.Users.Add(user);
            _EVContext.SaveChanges();
        }
    }
}
