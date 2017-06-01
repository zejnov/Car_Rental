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
    public class CarForRentDtoServices
    {
        /// <summary>
        /// Dodaje nowy, unikatowy nowy CarForRent, zwraca false jeżeli taki już jest
        /// </summary>
        /// <param name="carForRentDto"></param>
        /// <returns></returns>
        public static bool Add(CarForRentDto carForRentDto)
        {
            if (Exist(carForRentDto))
                return false;

            carForRentDto.IsRented = false;

            return new CarForRentRepository().Add(DtoToEntityMapper.CarForRentEntityModelToDto(carForRentDto));
        }

        /// <summary>
        /// Sprawdza czy dany Dto istniej jako model w bazie danych
        /// </summary>
        /// <param name="carForRentDto"></param>
        /// <returns></returns>
        public static bool Exist(CarForRentDto carForRentDto)
        {
            return new CarForRentRepository()
                .Exist(DtoToEntityMapper.CarForRentEntityModelToDto(carForRentDto));
        }

        /// <summary>
        /// Zwraca wszystkie modele jako lista Dto z bazy danych
        /// </summary>
        /// <returns></returns>
        public static List<CarForRentDto> GetAll()
        {
            return new CarForRentRepository()
                .GetAll()
                .Select(EntityToDtoMapper.CarForRentEntityModelToDto)
                .ToList();
        }

        
    }
}
