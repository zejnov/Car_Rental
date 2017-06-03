using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCar.DataLayer.Models;
using RentalCar.DataLayer.Repository.Basic;

namespace RentalCar.DataLayer.Repository
{
    public class SaleRepository : BasicRepository<Sale>
    {
        /// <summary>
        /// Dodawanie modelu Sale do bazy danych
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override bool Add(Sale model)
        {
            return ExecuteQuery(dbContext =>
            {
                dbContext.SaleDbSet.Add(model);
                return true;
            });
        }

        /// <summary>
        /// Pobieranie z bazy modelu Sale po id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Sale Get(int id)
        {
            return ExecuteQuery(dbContext => dbContext.SaleDbSet.First(p => p.Id == id));
        }

        /// <summary>
        /// Zwracanie wszystki elementów CarType z tabeli
        /// </summary>
        /// <returns></returns>
        public override List<Sale> GetAll()
        {
            return ExecuteQuery(dbContext => dbContext.SaleDbSet.ToList());
        }

        /// <summary>
        /// Sprawdzanie czy Sale istnieje w bazie danych
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override bool Exist(Sale model)
        {
            return ExecuteQuery(dbContext =>
            {
                var data = dbContext.SaleDbSet
                    .FirstOrDefault(p => p.Name == model.Name && p.AmmountPercentage == model.AmmountPercentage);

                return data != null;
            });
        }
    }
}
