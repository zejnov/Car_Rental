using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCar.DataLayer.Models;
using RentalCar.DataLayer.Repository.Basic;
using RentalCar.DataLayer.Repository.Interfaces;

namespace RentalCar.DataLayer.Repository
{
    /// <summary>
    /// Repo obługujące CarForRent
    /// </summary>
    public class CarForRentRepository : BasicRepository<CarForRent>, ICarForRentRepository
    {
        /// <summary>
        /// Dodaje nowy CarForRent 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override bool Add(CarForRent model)
        {
            return ExecuteQuery(dbContext =>
            {
                dbContext.CarTypesDbSet.Attach(model.TypeOfCar);
                dbContext.CarForRentsDbSet.Add(model);
                return true;
            });
        }

        /// <summary>
        /// Pobiera CarForRent po id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override CarForRent Get(int id)
        {
            return ExecuteQuery(dbContext => dbContext.CarForRentsDbSet
                .Include(x => x.TypeOfCar)
                .First(p => p.Id == id));
        }

        /// <summary>
        /// Pobiera wszystkie CarForRent
        /// </summary>
        /// <returns></returns>
        public override List<CarForRent> GetAll()
        {
            return ExecuteQuery(dbContext => dbContext.CarForRentsDbSet
                .Include(x => x.TypeOfCar)
                .ToList());
        }

        /// <summary>
        /// Sprawdza czy CarForRent istnieje w bazie danych po numerze rejestracyjnym
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override bool Exist(CarForRent model)
        {
            return ExecuteQuery(dbContext =>
            {
                var data = dbContext.CarForRentsDbSet
                    .FirstOrDefault(p => p.RegistrationNumber == model.RegistrationNumber);

                return data != null;
            });
        }
    }
}
