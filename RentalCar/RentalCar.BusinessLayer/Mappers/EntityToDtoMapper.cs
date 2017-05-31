﻿using System;
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
        public static CarTypeDto CarTypeEntityModelToDto(CarType carType)
        {
            if (carType == null)
            {
                return null;
            }

            return new CarTypeDto
            {
                Mark = carType.Mark,
                Model = carType.Model,
                PricePerDay = carType.PricePerDay,
            };
        }

    }
}
