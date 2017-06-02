using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCar.BusinessLayer.Dtos;
using RentalCar.DataLayer.Models;

namespace RentalCar.BusinessLayer.Mappers
{
    public class DtoToEntityMapper
    {
        /// <summary>
        /// Mapuje Customer z Dto do Entity
        /// </summary>
        /// <param name="customerDto">ModelDto</param>
        /// <returns>Model</returns>
        public static Customer CustomerDtoToEntityModel(CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                return null;
            }

            return new Customer()
            {
                Id = customerDto.Id,
                Name = customerDto.Name,
                Surname = customerDto.Surname,
                Pesel = customerDto.Pesel
            };

        }

        /// <summary>
        /// Mapuje CarForRent z Dto do Entity
        /// </summary>
        /// <param name="carForRent">ModelDto</param>
        /// <returns>Model</returns>
        public static CarForRent CarForRentEntityModelToDto(CarForRentDto carForRent)
        {
            if (carForRent == null)
            {
                return null;
            }

            return new CarForRent
            {
                Id = carForRent.Id,
                RegistrationNumber = carForRent.RegistrationNumber,
                IsRented = carForRent.IsRented,
                TypeOfCar = CarTypeDtoToEntityModel(carForRent.TypeOfCar)
            };
        }

        /// <summary>
        /// Mapuje CarType z Dto do Entity
        /// </summary>
        /// <param name="carType">ModelDto</param>
        /// <returns>Model</returns>
        public static CarType CarTypeDtoToEntityModel(CarTypeDto carType)
        {
            if (carType == null)
            {
                return null;
            }

            return new CarType
            {
                Id = carType.Id,
                Mark = carType.Mark,
                Model = carType.Model,
                PricePerDay = carType.PricePerDay,
            };
        }


    }
}
