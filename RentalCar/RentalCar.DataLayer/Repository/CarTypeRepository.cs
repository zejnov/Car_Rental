using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCar.DataLayer.Models;
using RentalCar.DataLayer.Repository.Basic;
using RentalCar.DataLayer.Repository.Interfaces;

namespace RentalCar.DataLayer.Repository
{
    /// <summary>
    /// Klasa obługująca model CarType w relacji z bazą
    /// </summary>
    public class CarTypeRepository : BasicRepository<CarType>, ICarTypeRepository
    {
        /// <summary>
        /// Dodawanie modelu CarType do bazy danych
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override bool Add(CarType model)
        {
            return ExecuteQuery(dbContext =>
            {
                dbContext.CarTypesDbSet.Add(model);
                return true;
            });
        }

        /// <summary>
        /// Pobieranie z bazy modelu CarType po id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override CarType Get(int id)
        {
            return ExecuteQuery(dbContext => dbContext.CarTypesDbSet.First(car => car.Id == id));
        }

        /// <summary>
        /// Zwracanie wszystki elementów CarType z tabeli
        /// </summary>
        /// <returns></returns>
        public override List<CarType> GetAll()
        {
            return ExecuteQuery(dbContext => dbContext.CarTypesDbSet.ToList());
        }

        /// <summary>
        /// Sprawdzanie czy CarType istnieje w bazie danych
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override bool Exist(CarType model)
        {
            return ExecuteQuery(dbContext =>
            {
                var data = dbContext.CarTypesDbSet
                    .FirstOrDefault(p => p.Mark == model.Mark && p.Model == model.Model);

                return data != null;
            });
        }
    }
}
