using System.Collections.Generic;
using RentalCar.DataLayer.Models;

namespace RentalCar.DataLayer.Repository.Interfaces
{
    public interface ICarRentedByCustomer
    {
        bool Add(CarsRentedByCustomers model);
        bool Exist(CarsRentedByCustomers model);
        CarsRentedByCustomers Get(int id);
        List<CarsRentedByCustomers> GetAll();
        bool Return(CarsRentedByCustomers model);
    }
}