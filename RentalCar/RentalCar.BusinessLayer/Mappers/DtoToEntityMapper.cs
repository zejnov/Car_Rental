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
                Mark = carType.Mark,
                Model = carType.Model,
                PricePerDay = carType.PricePerDay,
            };
        }


    }
}
