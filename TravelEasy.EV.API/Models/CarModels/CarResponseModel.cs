using MessagePack.Formatters;

namespace TravelEasy.EV.API.Models.CarModels
{
    public class CarResponseModel
    {
        public string Brand { get; set; } 
        public string Model { get; set; } 
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}
