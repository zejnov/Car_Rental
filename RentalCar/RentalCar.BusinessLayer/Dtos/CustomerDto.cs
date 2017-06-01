using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.BusinessLayer.Dtos
{
    class CustomerDto
    {
        /// <summary>
        /// ID klienta
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Imię klienta
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Nazwisko klienta
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// PESEL klienta (niepowtarzalny)
        /// </summary>
        public long Pesel { get; set; }

        /// <summary>
        /// Sprawdza czy klienci są równi
        /// </summary>
        /// <param name="obj">Model</param>
        /// <returns>IsEqual</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var customerDto = obj as CustomerDto;

            bool isEqual = true;
            isEqual &= Id == customerDto.Id;
            isEqual &= Name == customerDto.Name;
            isEqual &= Surname == customerDto.Surname;
            isEqual &= Pesel == customerDto.Pesel;

            return isEqual;
        }
    }
}
