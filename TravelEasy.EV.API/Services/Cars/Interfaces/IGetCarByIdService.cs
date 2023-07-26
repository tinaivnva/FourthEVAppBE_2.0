using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Cars.Interfaces
{
    public interface IGetCarByIdService
    {
        public string? Brand { get; set; }

        public string? Model { get; set; }

        public int HorsePowers { get; set; }

        public int Range { get; set; }

        public decimal PricePerDay { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public void 
    }
}
