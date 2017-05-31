using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.BusinessLayer.Dtos
{
    public class CarForRentDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Numer rejestracyjny pojazdu
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Czy pojazd jest wypożyczony
        /// </summary>
        public bool IsRented { get; set; }

        /// <summary>
        /// Typ samochodu
        /// </summary>
        public CarTypeDto TypeOfCar { get; set; }
    }
}
