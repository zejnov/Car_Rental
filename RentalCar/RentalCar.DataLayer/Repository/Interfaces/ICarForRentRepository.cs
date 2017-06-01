using System.Collections.Generic;
using RentalCar.DataLayer.Models;

namespace RentalCar.DataLayer.Repository.Interfaces
{
    public interface ICarForRentRepository
    {
        bool Add(CarForRent model);
        bool Exist(CarForRent model);
        CarForRent Get(int id);
        List<CarForRent> GetAll();
    }
}