using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalCar.BusinessLayer.Dtos;
using RentalCar.BusinessLayer.Services;

namespace RentalCar.BusinessLayer.Tests
{
    /// <summary>
    /// Testuje customer services
    /// </summary>
    [TestClass]
    public class CarRentedByCustomerServiceTests
    {
        /// <summary>
        /// Sprawdza czy cena bez rabatu jest poprawnie obliczana
        /// </summary>
        [TestMethod]
        public void GetPrice_ValidCarRentedByCustomerWidthoutRabat_PriceDoubleReturned()
        {
            var inputRented = GetRent();

            inputRented.Customer.CarsRentedByCustomersList.Add(inputRented);
            inputRented.CarForRental.CarsRentedByCustomersList.Add(inputRented);

            var price = CarRentedByCustomerDtoServices.GetPrice(inputRented, 0);

            Assert.AreEqual(400D, price);
        }

        /// <summary>
        /// Sprawdza czy cena z rabatem jest poprawnie obliczana
        /// </summary>
        [TestMethod]
        public void GetPrice_ValidCarRentedByCustomerWidthRabat_PriceDoubleReturned()
        {
            var inputRented = GetRent();

            for (int i = 0; i < 11; i++)
            {
                inputRented.Customer.CarsRentedByCustomersList.Add(inputRented);
            }

            inputRented.CarForRental.CarsRentedByCustomersList.Add(inputRented);

            var price = CarRentedByCustomerDtoServices.GetPrice(inputRented, 10);

            Assert.AreEqual(360D, price);
        }

        [TestMethod]
        public void SumRabat_RabatAmountGraterThan100_Return100()
        {
            var inputRented = GetRent();

            for (int i = 0; i < 11; i++)
            {
                inputRented.Customer.CarsRentedByCustomersList.Add(inputRented);
            }

            var rabat =
                CarRentedByCustomerDtoServices.SumRabat(inputRented.Customer, 98);

            Assert.AreEqual(100, rabat);
        }

        [TestMethod]
        public void SumRabat_RabatAmount50_Return50()
        {
            var inputRented = GetRent();

            for (int i = 0; i < 11; i++)
            {
                inputRented.Customer.CarsRentedByCustomersList.Add(inputRented);
            }

            var rabat =
                CarRentedByCustomerDtoServices.SumRabat(inputRented.Customer, 45);

            Assert.AreEqual(50, rabat);
        }

        private CarsRentedByCustomersDto GetRent()
        {
            return new CarsRentedByCustomersDto()
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
        }
    }
}
