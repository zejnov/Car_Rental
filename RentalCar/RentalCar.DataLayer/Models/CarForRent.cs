using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.DataLayer.Models
{
    public class CarForRent
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
        public CarType TypeOfCar { get; set; }

        /// <summary>
        /// Sprawdza czy obiekty są równe
        /// </summary>
        /// <param name="obj">Model</param>
        /// <returns>IsEqual</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var carForRent = obj as CarForRent;

            bool isEqual=true;
            isEqual &= Id == carForRent.Id;
            isEqual &= RegistrationNumber == carForRent.RegistrationNumber;
            isEqual &= IsRented == carForRent.IsRented;
            isEqual &= TypeOfCar.Equals(carForRent.TypeOfCar);
            
            return isEqual;
        }

    }
}
