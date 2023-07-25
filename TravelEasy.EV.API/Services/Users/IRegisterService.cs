using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEasy.EV.DataLayer;

namespace TravelEasy.EV.API.Services

{
    public class IRegisterService
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }

        /*public void UserAuthentification(int userId);
        public void UserRegister();*/

    }
}
