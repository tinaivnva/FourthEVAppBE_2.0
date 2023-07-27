using TravelEasy.ElectricVehicles.DB.Models;
using TravelEasy.EV.DataLayer;

namespace Service.CarBooking
{
    public interface IBookingService
    {
        public void AddBooking(BookedCar bookedCars);
        public bool CheckIfBookingExists(int bookingId);
        public BookedCar GetBookingByID(int bookingId);
        public BookedCar GetBookingByCarID(int carId);
        public ICollection<ElectricVehicle> GetBookedVehicles();
        public ICollection<BookedCar> GetUserBookings(int userId);

    }
}
