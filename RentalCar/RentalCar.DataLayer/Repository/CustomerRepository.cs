using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCar.DataLayer.Models;
using RentalCar.DataLayer.Repository.Basic;

namespace RentalCar.DataLayer.Repository
{ 
    /// <summary>
    /// Obługa customera z bazą danych
    /// </summary>
    public class CustomerRepository : BasicRepository<Customer>
    {
        /// <summary>
        /// Dodaje nowego customera
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override bool Add(Customer model)
        {
            return ExecuteQuery(dbContext =>
            {
                dbContext.CustomersDbSet.Add(model);
                return true;
            });
        }

        /// <summary>
        /// Pobiera Customer po id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Customer Get(int id)
        {
            return ExecuteQuery(dbContext => dbContext.CustomersDbSet
                .First(p => p.Id == id));
        }

        /// <summary>
        /// Pobiera wszystkie Customer z tabeli
        /// </summary>
        /// <returns></returns>
        public override List<Customer> GetAll()
        {
            return ExecuteQuery(dbContext => dbContext.CustomersDbSet
                .ToList());
        }

        /// <summary>
        /// Sprawdza czy Customer istnieje w bazie danych po PESELu
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override bool Exist(Customer model)
        {
            return ExecuteQuery(dbContext =>
            {
                var data = dbContext.CustomersDbSet
                    .FirstOrDefault(p => p.Pesel == model.Pesel);

                return data != null;
            });
        }
    }
}
