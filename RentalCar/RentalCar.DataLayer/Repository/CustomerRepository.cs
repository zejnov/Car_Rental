using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using RentalCar.DataLayer.Models;
using RentalCar.DataLayer.Repository.Basic;
using RentalCar.DataLayer.Repository.Interfaces;

namespace RentalCar.DataLayer.Repository
{ 
    /// <summary>
    /// Obługa customera z bazą danych
    /// </summary>
    public class CustomerRepository : BasicRepository<Customer>, ICustomerRepository
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
                .Include(p => p.CarsRentedByCustomersList.Select(x => x.CarForRental.TypeOfCar))
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

        /// <summary>
        /// Pobiera klienta po peselu
        /// </summary>
        /// <param name="pesel"></param>
        /// <returns></returns>
        public Customer Get(long pesel)
        {
            return ExecuteQuery(dbContext =>
            {
                return dbContext.CustomersDbSet
                    .Include(p => p.CarsRentedByCustomersList.Select(x => x.CarForRental.TypeOfCar))
                    .First(p => p.Pesel == pesel);
            });
        }

        /// <summary>
        /// Zmienia dane personalne klienta
        /// </summary>
        /// <param name="oldModel"></param>
        /// <param name="newModel"></param>
        /// <returns></returns>
        public bool UpdatePersonalData(Customer oldModel, Customer newModel)
        {
            return ExecuteQuery(dbContext =>
            {
                dbContext.CustomersDbSet.Attach(oldModel);
                oldModel.Name = newModel.Name;
                oldModel.Surname = newModel.Surname;

                return true;
            });
        }
    }
}
