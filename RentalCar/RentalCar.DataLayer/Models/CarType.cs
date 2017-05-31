using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.DataLayer.Models
{
    public class CarType
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public int PricePerDay { get; set; }
    }
}
