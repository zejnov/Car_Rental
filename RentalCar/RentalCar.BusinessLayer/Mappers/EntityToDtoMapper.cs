using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCar.BusinessLayer.Dtos;
using RentalCar.DataLayer.Models;

namespace RentalCar.BusinessLayer.Mappers
{
    public class EntityToDtoMapper
    {
        /// <summary>
        /// Mapuje CarForRent z Entity do Dto
        /// </summary>
        /// <param name="carForRent">Model</param>
        /// <returns>ModelDto</returns>
        public static CarForRentDto CarForRentEntityModelToDto (CarForRent carForRent)
        {
            if (carForRent == null)
            {
                return null;
            }

            return new CarForRentDto
            {
                Id = carForRent.Id,
                RegistrationNumber = carForRent.RegistrationNumber,
                IsRented = carForRent.IsRented,
                TypeOfCar = CarTypeEntityModelToDto(carForRent.TypeOfCar)
            };
        }


        /// <summary>
        /// Mapuje CarType z Entity do Dto
        /// </summary>
        /// <param name="carType">Model</param>
        /// <returns>ModelDto</returns>
        public static CarTypeDto CarTypeEntityModelToDto(CarType carType)
        {
            if (carType == null)
            {
                return null;
            }

            return new CarTypeDto
            {
                Id = carType.Id,
                Mark = carType.Mark,
                Model = carType.Model,
                PricePerDay = carType.PricePerDay,
            };
        }        
    }
}
