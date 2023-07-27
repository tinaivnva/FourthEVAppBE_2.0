using TravelEasy.EV.DataLayer;
using TravelEasy.ElectricVehicles.DB.Models;
using Service.Cars.Interfaces;

namespace Service.Booking
{
    public class BookingService : IBookingService
    {
        private readonly ICarsService _carsService;
        private readonly IBookingService _bookingService;
        private readonly ElectricVehiclesContext _EVContext;

        public BookingService(ElectricVehiclesContext EVContext, IBookingService bookingService, ICarsService carsService) 
        {
            _EVContext = EVContext;
            _carsService = carsService;
        }
        public void AddBooking(Booking booking)
        {
            _EVContext.Booking.Add(booking);
            _EVContext.SaveChanges();
        }

        public bool CheckIfBookingExists(int bookingId)
        {
            return _EVContext.Booking.Where(b => b.Id == bookingId).Any();
        }

        public bool CheckIfBookingExists()
        {
            throw new NotImplementedException();
        }

        public ICollection<ElectricVehicle> GetAvailableVehicles()
        {
            throw new NotImplementedException();
        }

        /*public ICollection<ElectricVehicle> GetAvailableVehicles()
        {
            ICollection<ElectricVehicle> availiableVehicles = new List<ElectricVehicle>();
            var vehicles = _carsService
            throw new NotImplementedException();
        }*/

        public ICollection<ElectricVehicle> GetBookedVehicles()
        {
            throw new NotImplementedException();
        }

        public void GetBookingByCarID(int bookingId)
        {
            throw new NotImplementedException();
        }

        public void GetBookingByID(int bookingId)
        {
            throw new NotImplementedException();
        }
    }
}
