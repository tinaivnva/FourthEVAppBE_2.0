﻿namespace TravelEasy.EV.API.Models.BookingModels
{
    public class BookingRequestModel
    {
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
