using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEasy.EV.DataLayer;
using TravelEasy.ElectricVehicles.DB.Models;

namespace Service.Booking
{
    public interface IBookingService
    {
        //public void AddBooking(Booking booking);
        public bool CheckIfBookingExists();
        public void GetBookingByID(int bookingId);
        public void GetBookingByCarID(int bookingId);
        public ICollection<ElectricVehicle> GetBookedVehicles();
        public ICollection<ElectricVehicle> GetAvailableVehicles();

    }
}
