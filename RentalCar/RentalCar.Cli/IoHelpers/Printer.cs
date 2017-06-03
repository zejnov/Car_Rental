using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCar.BusinessLayer.Dtos;
using RentalCar.Cli.Commands;

namespace RentalCar.Cli.IoHelpers
{
    public static class Printer
    {
        /// <summary>
        /// Wyświetla info o commandAction
        /// </summary>
        /// <param name="command"></param>
        public static void PrintObjectData(CommandAction command)
        {
            Console.WriteLine($"{command.Command} - {command.Description}");
        }

        /// <summary>
        /// Wyświetla element listy z danymi CarType
        /// </summary>
        /// <param name="carType"></param>
        /// <param name="ordinal"></param>
        public static void PrintOrderedList(CarTypeDto carType, int ordinal)
        {
            Console.WriteLine($"{ordinal}. {carType.Mark} {carType.Model} {carType.PricePerDay}zl/day");
        }

        /// <summary>
        /// Wyświetla element listy z danymi klienta
        /// </summary>
        /// <param name="sale"></param>
        /// <param name="ordinal"></param>
        public static void PrintOrderedList(SaleDto sale, int ordinal)
        {
            Console.WriteLine($"{ordinal}. {sale.Name} {sale.AmmountPercentage}%");
        }

        /// <summary>
        /// Wyświetla element listy z danymi klienta
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="ordinal"></param>
        public static void PrintOrderedList(CustomerDto customer, int ordinal)
        {
            Console.WriteLine($"{ordinal}. {customer.Name} {customer.Surname} {customer.Pesel}");
        }

        /// <summary>
        /// Wyświetla element listy z autem do wypożyczenia klienta
        /// </summary>
        /// <param name="car"></param>
        /// <param name="ordinal"></param>
        public static void PrintOrderedList(CarForRentDto car, int ordinal)
        {
            Console.WriteLine(
                $"{ordinal}. {car.TypeOfCar.Mark} {car.TypeOfCar.Model} {car.TypeOfCar.PricePerDay}zl/day {car.RegistrationNumber}");
        }

        /// <summary>
        /// Wyświetla listę samochodów wyporzyczonych przez klienta
        /// </summary>
        /// <param name="rentalCar"></param>
        /// <param name="ordinal"></param>
        public static void PrintOrderedList(CarsRentedByCustomersDto rentalCar, int ordinal)
        {
            Console.WriteLine(
                $"{ordinal}. {rentalCar.CarForRental.RegistrationNumber} {rentalCar.CarForRental.TypeOfCar.Mark} {rentalCar.CarForRental.TypeOfCar.Model}" +
                $"\nRented since " + StringDate(rentalCar.RentalDateTime.Value));
        }

        /// <summary>
        /// Drukuje liste CarType zgromadzoną w liście
        /// </summary>
        /// <param name="carTypeList"></param>
        public static void PrintCarTypeList(List<CarTypeDto> carTypeList)
        {
            foreach (var carType in carTypeList)
            {
                Console.WriteLine($"{carType.Id}. {carType.Mark} {carType.Model} " +
                                  $"costs {carType.PricePerDay} per day");
            }
        }

        /// <summary>
        /// zwraca date w przyzwoitym formacie
        /// </summary>
        /// <param name="dateTime">DataTime</param>
        /// <returns>Data string</returns>
        public static string StringDate(DateTime dateTime)
        {
            return ($"{dateTime.Day}/{dateTime.Month}/{dateTime.Year}");
        }

    }
}
