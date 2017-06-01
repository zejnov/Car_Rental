using System.Collections.Generic;
using RentalCar.DataLayer.Models;

namespace RentalCar.DataLayer.Repository.Interfaces
{
    public interface ICarTypeRepository
    {
        bool Add(CarType model);
        CarType Get(int id);
        List<CarType> GetAll();
        bool Exist(CarType model);
    }
}