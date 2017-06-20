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

        /// <summary>
        /// Zwraca kwotę z możliwym discountem
        /// </summary>
        /// <param name="rented"></param>
        /// <returns></returns>
        public static double GetPrice(CarsRentedByCustomersDto rented, int discount)
        {
            var rentingTime = DateTime.Today - rented.RentalDateTime;

            double price = rentingTime.Value.Days * rented.CarForRental.TypeOfCar.PricePerDay;

            price = price - (price / 100 * discount);

            if (price < 0)
                price = 0;

            return price;
        }

        public static int sumDiscount(CustomerDto customer, int choosenSale)
        {
            int discount = choosenSale;
            if (customer.CarsRentedByCustomersList.Count >= 10)
            {
                discount += 5;
            }

            if (discount > 100)
                discount = 100;

            return discount;
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
