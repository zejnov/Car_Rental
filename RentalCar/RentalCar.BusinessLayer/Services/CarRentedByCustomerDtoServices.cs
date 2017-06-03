﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCar.BusinessLayer.Dtos;
using RentalCar.BusinessLayer.Mappers;
using RentalCar.DataLayer.Repository;

namespace RentalCar.BusinessLayer.Services
{
    public class CarRentedByCustomerDtoServices
    {
        /// <summary>
        /// Dodaje nowy, unikatowy nowy Customer, zwraca false jeżeli taki już jest
        /// </summary>
        /// <param name="carRentedByCustomersDto"></param>
        /// <returns></returns>
        public static bool Add(CarsRentedByCustomersDto carRentedByCustomersDto)
        {
            carRentedByCustomersDto.RentalDateTime = DateTime.Today;

            //if (Exist(carRentedByCustomersDto))
             //   return false;

            return new CarRentedByCustomerRepository()
                .Add(DtoToEntityMapper.CarsRentedByCustomersDtoToEntity(carRentedByCustomersDto));
        }

        /// <summary>
        /// Sprawdza czy dany Dto istniej jako model w bazie danych
        /// </summary>
        /// <param name="carRentedByCustomerDto"></param>
        /// <returns></returns>
        public static bool Exist(CarsRentedByCustomersDto carRentedByCustomerDto)
        {
            return new CarRentedByCustomerRepository()
                .Exist(DtoToEntityMapper.CarsRentedByCustomersDtoToEntity(carRentedByCustomerDto));
        }

        /// <summary>
        /// Zwraca wszystkie modele jako lista Dto z bazy danych
        /// </summary>
        /// <returns></returns>
        public static List<CarsRentedByCustomersDto> GetAll()
        {
            return new CarRentedByCustomerRepository()
                .GetAll()
                .Select(EntityToDtoMapper.CarsRentedByCustomersEntityModelToDto)
                .ToList();
        }

        /// <summary>
        /// Zwraca kwotę z możliwym rabatem
        /// </summary>
        /// <param name="rented"></param>
        /// <returns></returns>
        public static double GetPrice(CarsRentedByCustomersDto rented, CustomerDto customerDto)
        {
            var rentingTime = DateTime.Today - rented.RentalDateTime;

            double price = rentingTime.Value.Days * rented.CarForRental.TypeOfCar.PricePerDay;

            if (customerDto.CarsRentedByCustomersList.Count >= 10)
            {
                price = price - (price / 100) * 5;
            }

            return price;
        }

        /// <summary>
        /// Wywołuje repo które zwraca auto
        /// </summary>
        /// <param name="rent"></param>
        /// <returns></returns>
        public static bool ReturnCar(CarsRentedByCustomersDto rent, double price)
        {
            rent.TotalPrice = price;
            rent.ReturnDateTime = DateTime.Today;

            return new CarRentedByCustomerRepository()
                .Return(DtoToEntityMapper.CarsRentedByCustomersDtoToEntity(rent));
        }
    }
}
