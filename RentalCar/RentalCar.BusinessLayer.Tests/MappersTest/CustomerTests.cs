using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalCar.BusinessLayer.Dtos;
using RentalCar.BusinessLayer.Mappers;
using RentalCar.DataLayer.Models;

namespace RentalCar.BusinessLayer.Tests.MappersTest
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void CustomerMapping_ProvideValistCustomerDto_ReceiveProperlyMappedCustomer()
        {
            var customerToMap = new CustomerDto()
            {
                Id = 4,
                Name = "Janusz",
                Surname = "Kowal",
                Pesel = 55040134965,
            };

            var expectedCustomer = new Customer()
            {
                Id = 4,
                Name = "Janusz",
                Surname = "Kowal",
                Pesel = 55040134965,
            };

            var resultOfMapping = DtoToEntityMapper.CustomerDtoToEntityModel(customerToMap);

            Assert.IsTrue(resultOfMapping.Equals(expectedCustomer));
        }

        [TestMethod]
        public void CustomerMapping_ProvideValistCustomer_ReceiveProperlyMappedCustomerDto()
        {
            var customerToMap = new Customer()
            {
                Id = 4,
                Name = "Janusz",
                Surname = "Kowal",
                Pesel = 55040134965,
            };

            var expectedCustomer = new CustomerDto()
            {
                Id = 4,
                Name = "Janusz",
                Surname = "Kowal",
                Pesel = 55040134965,
            };

            var resultOfMapping = EntityToDtoMapper.CustomerEntityModelToDto(customerToMap);

            Assert.IsTrue(resultOfMapping.Equals(expectedCustomer));
        }

        [TestMethod]
        public void CustomerMapping_ProvideNullCustomer_ReceiveNullDto()
        {
            var customerToMap = new Customer();
            customerToMap = null;

            var expectedCustomer = new CustomerDto();
            expectedCustomer = null;

            var resultOfMapping = EntityToDtoMapper.CustomerEntityModelToDto(customerToMap);

            Assert.AreEqual(resultOfMapping, expectedCustomer);
        }

        [TestMethod]
        public void CustomerMapping_ProvideNullCustomerDto_ReceiveNull()
        {
            var customerToMap = new CustomerDto();
            customerToMap = null;

            var expectedCustomer = new Customer();
            expectedCustomer = null;

            var resultOfMapping = DtoToEntityMapper.CustomerDtoToEntityModel(customerToMap);

            Assert.AreEqual(resultOfMapping, expectedCustomer);
        }

    }
}
