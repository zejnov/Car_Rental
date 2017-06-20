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
        /// Mapuje Sale z Entity do Dto
        /// </summary>
        /// <param name="sale">Model</param>
        /// <returns>ModelDto</returns>
        public static SaleDto SaleEntityModelToDto(Sale sale)
        {
            if (sale == null)
            {
                return null;
            }
            return new SaleDto()
            {
                Id = sale.Id,
                Name = sale.Name,
                AmmountPercentage = sale.AmmountPercentage
            };
        }
        
        /// <summary>
        /// Mapuje relację Customer - CarForRent z Entity do Dto
        /// </summary>
        /// <param name="carsRentedByCustomers"></param>
        /// <returns></returns>
        public static CarsRentedByCustomersDto CarsRentedByCustomersEntityModelToDto(CarsRentedByCustomers carsRentedByCustomers)
        {
            if (carsRentedByCustomers == null)
            {
                return null;
            }

            return new CarsRentedByCustomersDto()
            {
                Id = carsRentedByCustomers.Id,
                CarForRental =
                    CarForRentEntityModelToDto(carsRentedByCustomers.CarForRental),

                RentalDateTime = carsRentedByCustomers.RentalDateTime,
                ReturnDateTime = carsRentedByCustomers.ReturnDateTime,

                TotalPrice = carsRentedByCustomers.TotalPrice,
                IsReturned = carsRentedByCustomers.IsReturned
            };

        }
        
        /// <summary>
        /// Mapuje Customer z Entity do Dto
        /// </summary>
        /// <param name="customerDto">Model</param>
        /// <returns>ModelDto</returns>
        public static CustomerDto CustomerEntityModelToDto(Customer customer)
        {
            if (customer == null)
            {
                return null;
            }

            return new CustomerDto()
            {
                Id = customer.Id,
                Name = customer.Name,
                Surname = customer.Surname,
                Pesel = customer.Pesel,
                CarsRentedByCustomersList = customer
                    .CarsRentedByCustomersList
                    .Select(CarsRentedByCustomersEntityModelToDto)
                    .ToList(),
            };

        }

        /// <summary>
        /// Mapuje CarForRent z Entity do Dto
        /// </summary>
        /// <param name="carForRent">Model</param>
        /// <returns>ModelDto</returns>
        public static CarForRentDto CarForRentEntityModelToDto(CarForRent carForRent)
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
                TypeOfCar = CarTypeEntityModelToDto(carForRent.TypeOfCar),
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
