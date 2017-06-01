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
    /// <summary>
    /// Serwisy do CarType
    /// </summary>
    public class CarTypeDtoServices
    {
        /// <summary>
        /// Dodaje nowy, unikatowy car type, zwraca false jeżeli taki już jest
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static bool Add(CarTypeDto carTypeDto)
        { 
            if (Exist(carTypeDto))
                return false;

            return new CarTypeRepository().Add(DtoToEntityMapper.CarTypeDtoToEntityModel(carTypeDto));
        }

        /// <summary>
        /// Sprawdza czy dany Dto istniej jako model w bazie danych
        /// </summary>
        /// <param name="carTypeDto"></param>
        /// <returns></returns>
        public static bool Exist(CarTypeDto carTypeDto)
        {
            return new CarTypeRepository()
                .Exist(DtoToEntityMapper.CarTypeDtoToEntityModel(carTypeDto));
        }

        /// <summary>
        /// Zwraca wszystkie modele jako lista Dto z bazy danych
        /// </summary>
        /// <returns></returns>
        public static List<CarTypeDto> GetAll()
        {
            return new CarTypeRepository()
                .GetAll()
                .Select(EntityToDtoMapper.CarTypeEntityModelToDto)
                .ToList();
        }
    }
}
