using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerApp.Commands;
using RentalCar.BusinessLayer.Dtos;

namespace CustomerApp.Cli.IoHelpers
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
        /// Wyświetla listę samochodów wyporzyczonych przez klienta
        /// </summary>
        /// <param name="rentalCar"></param>
        /// <param name="ordinal"></param>
        public static void PrintOrderedList(CarsRentedByCustomersDto rentalCar, int ordinal)
        {
            if (rentalCar.IsReturned)
            {
                Console.WriteLine(
                    $"{ordinal}. {rentalCar.CarForRental.RegistrationNumber} {rentalCar.CarForRental.TypeOfCar.Mark} {rentalCar.CarForRental.TypeOfCar.Model}" +
                    $"\nRented from  {StringDate(rentalCar.RentalDateTime)} to {StringDate(rentalCar.ReturnDateTime)}, price: {rentalCar.TotalPrice}zl");
            }
            else
            {
                Console.WriteLine($"{ordinal}. {rentalCar.CarForRental.RegistrationNumber} {rentalCar.CarForRental.TypeOfCar.Mark} {rentalCar.CarForRental.TypeOfCar.Model}");
                Console.WriteLine($"Current in use since {rentalCar.RentalDateTime.Value.ToShortDateString()}");
            }
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
        public static string StringDate(DateTime? dateTime)
        {
            return ($"{dateTime.Value.Day}/{dateTime.Value.Month}/{dateTime.Value.Year}");
        }
    }
}
