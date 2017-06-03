using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalCar.BusinessLayer.Dtos;
using RentalCar.BusinessLayer.Services;

namespace RentalCar.BusinessLayer.Tests
{
    [TestClass]
    public class CarRentedByCustomerServiceTests
    {
        [TestMethod]
        public void GetPrice_ValidCarRentedByCustomerWidthoutRabat_PriceDoubleReturned()
        {
            var inputRented = new CarsRentedByCustomersDto()
            {
                Customer = new CustomerDto()
                {
                  Id  = 1,
                  Name = "Test",
                  Pesel = 12345678901,
                  Surname = "Test",                 
                },

                Id = 10,
                CarForRental = new CarForRentDto()
                {
                    TypeOfCar = new CarTypeDto()
                    {
                        Mark = "Test",
                        PricePerDay = 200,
                        Model = "Test",
                        Id = 5
                    },
                    Id = 20,
                    IsRented = true,
                    RegistrationNumber = "Test"
                },
                IsReturned = false,
                RentalDateTime = new DateTime(2017,06,01),
            };

            inputRented.Customer.CarsRentedByCustomersList.Add(inputRented);
            inputRented.CarForRental.CarsRentedByCustomersList.Add(inputRented);

            var price = CarRentedByCustomerDtoServices.GetPrice(inputRented);

            Assert.AreEqual(400D, price);
        }

        [TestMethod]
        public void GetPrice_ValidCarRentedByCustomerWidthRabat_PriceDoubleReturned()
        {
            var inputRented = new CarsRentedByCustomersDto()
            {
                Customer = new CustomerDto()
                {
                    Id = 1,
                    Name = "Test",
                    Pesel = 12345678901,
                    Surname = "Test",
                },

                Id = 10,
                CarForRental = new CarForRentDto()
                {
                    TypeOfCar = new CarTypeDto()
                    {
                        Mark = "Test",
                        PricePerDay = 200,
                        Model = "Test",
                        Id = 5
                    },
                    Id = 20,
                    IsRented = true,
                    RegistrationNumber = "Test"
                },
                IsReturned = false,
                RentalDateTime = new DateTime(2017, 06, 01),
            };

            for (int i = 0; i < 11; i++)
            {
                inputRented.Customer.CarsRentedByCustomersList.Add(inputRented);
            }

            inputRented.CarForRental.CarsRentedByCustomersList.Add(inputRented);

            var price = CarRentedByCustomerDtoServices.GetPrice(inputRented);

            Assert.AreEqual(380D, price);
        }
    }
}
