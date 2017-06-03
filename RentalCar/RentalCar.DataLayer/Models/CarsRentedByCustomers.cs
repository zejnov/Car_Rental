using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.DataLayer.Models
{
    public class CarsRentedByCustomers
    {
        /// <summary>
        /// ID powiązania 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Samochód do wyporzeczenia
        /// </summary>
        public CarForRent CarForRental { get; set; }

        /// <summary>
        /// Klient Wyporzyczający
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Data wypożyczenia
        /// </summary>
        public DateTime? RentalDateTime { get; set; }

        /// <summary>
        /// Data zwrócenia
        /// </summary>
        public DateTime? ReturnDateTime { get; set; }

        /// <summary>
        /// Zwraca czy został oddany do wyporzyczalni
        /// </summary>
        public bool IsReturned { get; set; }

        /// <summary>
        /// Całkowity koszt wyporzyczenia
        /// </summary>
        public double TotalPrice { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var carsRentedByCustomers = obj as CarsRentedByCustomers;

            bool isEqual = true;
            isEqual &= Id == carsRentedByCustomers.Id;
            isEqual &= CarForRental.Equals(carsRentedByCustomers.CarForRental);
            isEqual &= Customer.Equals(carsRentedByCustomers.Customer);
            isEqual &= RentalDateTime == carsRentedByCustomers.RentalDateTime;

            return isEqual;
        }

    }
}
