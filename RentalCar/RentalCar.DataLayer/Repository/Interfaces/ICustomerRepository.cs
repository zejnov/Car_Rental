using System.Collections.Generic;
using RentalCar.DataLayer.Models;

namespace RentalCar.DataLayer.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        bool Add(Customer model);
        bool Exist(Customer model);
        Customer Get(int id);
        List<Customer> GetAll();
        bool UpdatePersonalData(Customer oldModel, Customer newModel);
        Customer Get(long pesel);
    }
}