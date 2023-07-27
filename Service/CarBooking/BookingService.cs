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

        public void AddBooking(BookedCar booking)
        {
            _EVContext.BookedCars.Add(booking);
            _EVContext.SaveChanges();
        }

        public bool CheckIfBookingExists(int bookingId)
        {
            return _EVContext.BookedCars.Where(b => b.Id == bookingId).Any();
        }

        public BookedCar GetBookingByCarID(int carId)
        {
            return _EVContext.BookedCars.Where(b => b.Id == carId).FirstOrDefault();
        }

        public ICollection<ElectricVehicle> GetAvailableVehicles()
        {
            throw new NotImplementedException();
            /*ICollection<ElectricVehicle> availiableVehicles = new List<ElectricVehicle>();
            var vehicles = _carsService.GetAll();
            foreach (var vehicle in vehicles)
            {
                if (GetBookingByCarID(carId: (int)b.Id) != null)
                {
                    availiableVehicles.Add(vehicle);
                }
            }
            return availiableVehicles;*/
        }

        public ICollection<ElectricVehicle> GetBookedVehicles()
        {
            throw new NotImplementedException();
        }

        public BookedCar GetBookingByID(int bookingId)
        {
            throw new NotImplementedException();
        }
    }
}
