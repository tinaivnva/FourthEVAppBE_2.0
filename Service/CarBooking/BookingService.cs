using TravelEasy.EV.DataLayer;
using TravelEasy.ElectricVehicles.DB.Models;
using TravelEasy.EV.Services.Cars;

namespace Service.CarBooking
{
    public class BookingService : IBookingService
    {
        private readonly ICarsService _carsService;
        private readonly ElectricVehiclesContext _EVContext;

        public BookingService(ElectricVehiclesContext EVContext, ICarsService carsService) 
        {
            _EVContext = EVContext;
            _carsService = carsService;
        }

        public void AddBooking(BookedCar bookedCar)
        {
            _EVContext.BookedCars.Add(bookedCar);
            _EVContext.SaveChanges();
        }

        public bool CheckIfBookingExists(int bookingId)
        {
            return _EVContext.BookedCars.Where(b => b.Id == bookingId).Any();
        }

        public BookedCar GetBookingByCarID(int carId)
        {
            return _EVContext.BookedCars.Where(b => b.ElectricVehicleId == carId).FirstOrDefault();
        }

        public ICollection<ElectricVehicle> GetBookedVehicles()
        {
            ICollection<ElectricVehicle> bookedCars = new List<ElectricVehicle>();
            foreach (var booking in _EVContext.BookedCars)
            {
                bookedCars.Add(_carsService.GetByID(booking.ElectricVehicleId));
            }
            return bookedCars;
        }

        public BookedCar GetBookingByID(int bookingId)
        {
            return _EVContext.BookedCars.Where(b => b.Id == bookingId).FirstOrDefault();
        }

        public ICollection<BookedCar> GetUserBookings(int userId)
        {
            var userBookings = _EVContext.BookedCars.Where(b => b.UserId == userId);

            return userBookings.ToList();
        }

    }
}
