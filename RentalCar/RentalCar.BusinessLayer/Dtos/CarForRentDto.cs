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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj">ModelDto</param>
        /// <returns>IsEqual</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var carForRentDto = obj as CarForRentDto;

            bool isEqual = true;
            isEqual &= Id == carForRentDto.Id;
            isEqual &= RegistrationNumber == carForRentDto.RegistrationNumber;
            isEqual &= IsRented == carForRentDto.IsRented;
            isEqual &= TypeOfCar.Equals(carForRentDto.TypeOfCar);

            return isEqual;
        }
    }
}
