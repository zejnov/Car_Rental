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
        /// Sprawdza czy cena bez discountu jest poprawnie obliczana
        /// </summary>
        [TestMethod]
        public void GetPrice_ValidCarRentedByCustomerWidthoutdiscount_PriceDoubleReturned()
        {
            var inputRented = GetRent();

            inputRented.Customer.CarsRentedByCustomersList.Add(inputRented);
            inputRented.CarForRental.CarsRentedByCustomersList.Add(inputRented);

            var price = CarRentedByCustomerDtoServices.GetPrice(inputRented, 0);

            Assert.AreEqual(400D, price);
        }

        /// <summary>
        /// Sprawdza czy cena z discountem jest poprawnie obliczana
        /// </summary>
        [TestMethod]
        public void GetPrice_ValidCarRentedByCustomerWidthdiscount_PriceDoubleReturned()
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
        public void sumDiscount_discountAmountGraterThan100_Return100()
        {
            var inputRented = GetRent();

            for (int i = 0; i < 11; i++)
            {
                inputRented.Customer.CarsRentedByCustomersList.Add(inputRented);
            }

            var discount =
                CarRentedByCustomerDtoServices.sumDiscount(inputRented.Customer, 98);

            Assert.AreEqual(100, discount);
        }

        [TestMethod]
        public void sumDiscount_discountAmount50_Return50()
        {
            var inputRented = GetRent();

            for (int i = 0; i < 11; i++)
            {
                inputRented.Customer.CarsRentedByCustomersList.Add(inputRented);
            }

            var discount =
                CarRentedByCustomerDtoServices.sumDiscount(inputRented.Customer, 45);

            Assert.AreEqual(50, discount);
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

        [TestMethod]
        public void Test()
        {
            

        }
    }
}
