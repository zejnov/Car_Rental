using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.DataLayer.Models
{
    public class CarType
    {
        /// <summary>
        /// Marka pojazdu
        /// </summary>
        public string Mark { get; set; }

        /// <summary>
        /// Model pojazdu
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// koszt za dzień wyporzyczenia
        /// </summary>
        public int PricePerDay { get; set; }
    }
}
