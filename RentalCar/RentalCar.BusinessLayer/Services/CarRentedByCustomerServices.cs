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
    public class CarRentedByCustomerServices
    {
        /// <summary>
        /// Dodaje nowy, unikatowy nowy Customer, zwraca false jeżeli taki już jest
        /// </summary>
        /// <param name="carRentedByCustomersDto"></param>
        /// <returns></returns>
        public static bool Add(CarsRentedByCustomersDto carRentedByCustomersDto)
        {
            if (Exist(carRentedByCustomersDto))
                return false;

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
    }
}
