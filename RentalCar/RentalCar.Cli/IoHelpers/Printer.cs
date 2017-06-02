using System;
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
    }
}
