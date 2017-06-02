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
    public class CarRentedByCustomerRepository : BasicRepository<CarsRentedByCustomers>, ICarRentedByCustomer
    { 
        /// <summary>
        /// Dodawanie modelu CarType do bazy danych
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override bool Add(CarsRentedByCustomers model)
        {
            return ExecuteQuery(dbContext =>
            {
                dbContext.CustomersDbSet.Attach(model.Customer);
                dbContext.CarForRentsDbSet.Attach(model.CarForRental);

                model.CarForRental.IsRented = true;

                dbContext.CarsRentedByCustomersesDbSet.Add(model);

                model.Customer.CarsRentedByCustomersList.Add(model);
                model.CarForRental.CarsRentedByCustomersList.Add(model);

                return true;
            });
        }

        /// <summary>
        /// Pobieranie z bazy modelu CarType po id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override CarsRentedByCustomers Get(int id)
        {
            return ExecuteQuery(dbContext => dbContext.CarsRentedByCustomersesDbSet
                .Include(p => p.Customer)
                .Include(p => p.CarForRental)
                .First(p => p.Id == id));
        }

        /// <summary>
        /// Zwracanie wszystki elementów CarType z tabeli
        /// </summary>
        /// <returns></returns>
        public override List<CarsRentedByCustomers> GetAll()
        {
            return ExecuteQuery(dbContext => dbContext.CarsRentedByCustomersesDbSet
                .Include(p => p.Customer)
                .Include(p => p.CarForRental)
                .ToList());
        }

        /// <summary>
        /// Sprawdzanie czy CarType istnieje w bazie danych
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override bool Exist(CarsRentedByCustomers model)
        {
            return ExecuteQuery(dbContext =>
            {
                var data = dbContext.CarsRentedByCustomersesDbSet
                    .FirstOrDefault(p => 
                        p.Customer.Equals(model.Customer) 
                        && p.CarForRental.Equals(model.CarForRental) 
                        && p.RentalDateTime.Equals(model.RentalDateTime));

                return data != null;
            });
        }
    }
}
