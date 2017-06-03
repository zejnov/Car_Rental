using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCar.BusinessLayer.Dtos;
using RentalCar.BusinessLayer.Mappers;
using RentalCar.DataLayer.Models;
using RentalCar.DataLayer.Repository;

namespace RentalCar.BusinessLayer.Services
{
    public class SaleDtoServices
    {
        // <summary>
        /// Dodaje nowy, unikatowy sale, zwraca false jeżeli taki już jest
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static bool Add(SaleDto saleDto)
        {
            if (Exist(saleDto))
                return false;

            return new SaleRepository().Add(DtoToEntityMapper.SaleEntityModelToDto(saleDto));
        }

        /// <summary>
        /// Sprawdza czy dany Dto istniej jako model w bazie danych
        /// </summary>
        /// <param name="saleDto"></param>
        /// <returns></returns>
        public static bool Exist(SaleDto saleDto)
        {
            return new SaleRepository()
                .Exist(DtoToEntityMapper.SaleEntityModelToDto(saleDto));
        }

        /// <summary>
        /// Zwraca wszystkie modele jako lista Dto z bazy danych
        /// </summary>
        /// <returns></returns>
        public static List<SaleDto> GetAll()
        {
            return new SaleRepository()
                .GetAll()
                .Select(EntityToDtoMapper.SaleEntityModelToDto)
                .ToList();
        }
    }
}

