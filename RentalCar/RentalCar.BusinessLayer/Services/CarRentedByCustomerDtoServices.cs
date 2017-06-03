using System;
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

        public static double GetPrice(CarsRentedByCustomersDto rented)
        {
            var rentingTime = DateTime.Today - rented.RentalDateTime;

            double price = rentingTime.Days * rented.CarForRental.TypeOfCar.PricePerDay;

            if (rented.Customer.CarsRentedByCustomersList.Count >= 10)
            {
                price = price - (price / 100) * 5;
            }

            return price;
        }
    }
}
