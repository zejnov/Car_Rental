using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCar.BusinessLayer.Dtos;
using RentalCar.Cli.Exceptions;

namespace RentalCar.Cli.IoHelpers
{
    /// <summary>
    /// Klasa zawierające metody pytające użytkownika o wybór elementu z listy
    /// </summary>
    public static class ChooseFromList
    {
        /// <summary>
        /// Pyta użytkownika o wybranie konkretnego modelu
        /// </summary>
        /// <param name="carTypes"></param>
        /// <returns>CarType</returns>
        public static CarTypeDto CarTypeDto(List<CarTypeDto> carTypes)
        {
            int answer = 1;
            bool isAnswerCorrect = false;

            if (carTypes == null)
            {
                Console.WriteLine("There is no car type, add car type and then car for rent");
                return null;
            }

            int i = 1;
            foreach (var carType in carTypes)
            {
                Printer.PrintOrderedList(carType, i++);
            }

            Console.WriteLine();
            Console.Write("Please, chose number:");

            while (!isAnswerCorrect)
            {
                answer = Int32.Parse(Console.ReadLine());
                isAnswerCorrect = answer > 0 && answer <= carTypes.Count;

                if (!isAnswerCorrect)
                    Console.Write("Incorrect answer. Try again: ");
            }

            return carTypes[answer - 1];
        }

        /// <summary>
        /// Pyta użytkownika o wybranie konkretnego klienta
        /// </summary>
        /// <param name="customerDto"></param>
        /// <returns>Customer</returns>
        public static CustomerDto CustomerDto(List<CustomerDto> customerDto)
        {
            int answer = 1;
            bool isAnswerCorrect = false;

            if (customerDto.Count == 0)
            {
                return null;
            }

            int i = 1;
            foreach (var customer in customerDto)
            {
                Printer.PrintOrderedList(customer, i++);
            }

            Console.WriteLine();
            Console.Write("Please, chose number:");

            while (!isAnswerCorrect)
            {
                answer = Int32.Parse(Console.ReadLine());
                isAnswerCorrect = answer > 0 && answer <= customerDto.Count;

                if (!isAnswerCorrect)
                    Console.Write("Incorrect answer. Try again: ");
            }

            return customerDto[answer - 1];
        }

        /// <summary>
        /// Pyta użytkownika o wybranie konkretnego dostępnego samochodu
        /// </summary>
        /// <param name="customerForRentDto"></param>
        /// <returns>CarForRent</returns>
        public static CarForRentDto CarAvalibleForRent(List<CarForRentDto> carForRentDto)
        {
            int answer = 1;
            bool isAnswerCorrect = false;

            int i = 1;

            carForRentDto = carForRentDto.FindAll(p => !p.IsRented);

            if (carForRentDto.Count == 0)
            {
                return null;
            }

            foreach (var car in carForRentDto)
            {
                Printer.PrintOrderedList(car, i++);
            }

            Console.WriteLine();
            Console.Write("Please, choose number:");

            while (!isAnswerCorrect)
            {
                answer = Int32.Parse(Console.ReadLine());
                isAnswerCorrect = answer > 0 && answer <= carForRentDto.Count;

                if (!isAnswerCorrect)
                    Console.Write("Incorrect answer. Try again: ");
            }

            return carForRentDto[answer - 1];
        }

        /// <summary>
        /// Pyta użytkownika o wybranie konkretnego wypożyczonego przez klienta samochodu
        /// </summary>
        /// <param name="carsRentedByCustomer">Lista samochodów wyprozyczonych przez klienta</param>
        /// <returns>CarForRent</returns>
        public static CarsRentedByCustomersDto CarsRentedByCustomer(
            List<CarsRentedByCustomersDto> carsRentedByCustomer)
        {
            int answer = 1;
            bool isAnswerCorrect = false;

            int i = 1;

            carsRentedByCustomer = carsRentedByCustomer.FindAll(p => !p.IsReturned);

            if (carsRentedByCustomer.Count == 0)
            {
                return null;
            }

            foreach (var car in carsRentedByCustomer)
            {
                Printer.PrintOrderedList(car, i++);
            }

            Console.WriteLine();
            Console.Write("Please, choose number:");

            while (!isAnswerCorrect)
            {
                answer = Int32.Parse(Console.ReadLine());
                isAnswerCorrect = answer > 0 && answer <= carsRentedByCustomer.Count;

                if (!isAnswerCorrect)
                    Console.Write("Incorrect answer. Try again: ");
            }
            
            return carsRentedByCustomer[answer - 1];
        }

        /// <summary>
        /// Pyta użytkownika o wybranie konkretnego wypożyczonego przez klienta samochodu
        /// </summary>
        /// <param name="carsRentedByCustomer">Lista samochodów wyprozyczonych przez klienta</param>
        /// <returns>CarForRent</returns>
        public static int Sale(List<SaleDto> sales)
        {
            int answer = 1;
            bool isAnswerCorrect = false;

            int i = 1;

            if (sales.Count == 0)
            {
                return 0;
            }

            var tmp = sales;
            sales = new List<SaleDto>();
            sales.Add(new SaleDto()
            {
                Name = "Bez promocji",
                AmmountPercentage = 0,
            });
            sales.AddRange(tmp);

            foreach (var sale in sales)
            {
                Printer.PrintOrderedList(sale, i++);
            }

            Console.WriteLine();
            Console.Write("Please, choose number:");

            while (!isAnswerCorrect)
            {
                answer = Int32.Parse(Console.ReadLine());
                isAnswerCorrect = answer > 0 && answer <= sales.Count;

                if (!isAnswerCorrect)
                    Console.Write("Incorrect answer. Try again: ");
            }

            return sales[answer - 1].AmmountPercentage;
        }
    }
}
