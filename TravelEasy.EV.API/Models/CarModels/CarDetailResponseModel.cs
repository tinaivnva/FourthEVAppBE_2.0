namespace TravelEasy.EV.API.Models.CarModels
{
    public class CarDetailResponseModel
    {
        public string? Brand { get; set; }

        public string? Model { get; set; }

        public int HorsePowers { get; set; }

        public int Range { get; set; }

        public decimal PricePerDay { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
    }
}
