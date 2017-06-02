﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.BusinessLayer.Dtos
{
    public class CarsRentedByCustomersDto
    {

        /// <summary>
        /// ID powiązania 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Samochód do wyporzeczenia
        /// </summary>
        public CarForRentDto CarForRent { get; set; }

        /// <summary>
        /// Klient Wyporzyczający
        /// </summary>
        public CustomerDto Customer { get; set; }

        /// <summary>
        /// Data wypożyczenia
        /// </summary>
        public DateTime RentalDateTime { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var carsRentedByCustomersDto = obj as CarsRentedByCustomersDto;

            bool isEqual = true;
            isEqual &= Id == carsRentedByCustomersDto.Id;
            isEqual &= CarForRent.Equals(carsRentedByCustomersDto.CarForRent);
            isEqual &= Customer.Equals(carsRentedByCustomersDto.Customer);
            isEqual &= RentalDateTime == carsRentedByCustomersDto.RentalDateTime;

            return isEqual;
        }
    }
}
