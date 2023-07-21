using MessagePack.Formatters;

namespace TravelEasy.EV.API.Models.CarModels
{
    public class CarResponseModel
    {
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
