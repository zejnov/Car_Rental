using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerApp.Commands;
using RentalCar.BusinessLayer.Dtos;

namespace CustomerApp.Cli.IoHelpers
{
    class Printer
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
        /// Wyświetla listę samochodów wyporzyczonych przez klienta
        /// </summary>
        /// <param name="rentalCar"></param>
        /// <param name="ordinal"></param>
        public static void PrintOrderedList(CarsRentedByCustomersDto rentalCar, int ordinal)
        {
            Console.WriteLine(
                $"{ordinal}. {rentalCar.CarForRental.RegistrationNumber} {rentalCar.CarForRental.TypeOfCar.Mark} {rentalCar.CarForRental.TypeOfCar.Model}" +
                $"\nRented since " + StringDate(rentalCar.RentalDateTime));
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
