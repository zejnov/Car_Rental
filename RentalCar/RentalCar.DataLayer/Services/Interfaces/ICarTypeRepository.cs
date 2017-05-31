using System.Collections.Generic;
using RentalCar.DataLayer.Models;

namespace RentalCar.DataLayer.Services.Interfaces
{
    public interface ICarTypeRepository
    {
        bool Add(CarType model);
        CarType Get(int id);
        List<CarType> GetAll();
    }
}