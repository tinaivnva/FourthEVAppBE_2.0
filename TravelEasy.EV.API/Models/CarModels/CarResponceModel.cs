namespace TravelEasy.EV.API.Models.CarModels
{
    public class CarResponceModel
    {
        public string? Brand { get; set; }

        public string? Model { get; set; }

        public int HorsePowers { get; set; }

        public int Range { get; set; }

        public decimal PricePerDay { get; set; }
    }
}
