using System.Collections.Generic;
using RentalCar.DataLayer.Models;

namespace RentalCar.DataLayer.Repository.Interfaces
{
    public interface ISaleRepository
    {
        bool Add(Sale model);
        bool Exist(Sale model);
        Sale Get(int id);
        List<Sale> GetAll();
    }
}