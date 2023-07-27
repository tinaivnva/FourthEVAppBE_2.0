using TravelEasy.ElectricVehicles.DB.Models;

namespace Service.CarBooking
{
    public interface IBookingService
    {
        public void AddBooking(int booking);
        public bool CheckIfBookingExists();
        public void GetBookingByID(int bookingId);
        public void GetBookingByCarID(int bookingId);
        public ICollection<ElectricVehicle> GetBookedVehicles();
        public ICollection<ElectricVehicle> GetAvailableVehicles();

    }
}
