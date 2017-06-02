using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.DataLayer.Models
{
    public class Customer
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
        /// Lista "wypożyczeń"
        /// </summary>
        public List<CarsRentedByCustomers> CarsRentedByCustomersList { get; set; }

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

            var customer = obj as Customer;

            bool isEqual = true;
            isEqual &= Id == customer.Id;
            isEqual &= Name == customer.Name;
            isEqual &= Surname == customer.Surname;
            isEqual &= Pesel == customer.Pesel;

            return isEqual;
        }
    }
}
