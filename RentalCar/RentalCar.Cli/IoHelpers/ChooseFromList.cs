using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCar.BusinessLayer.Dtos;

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
        /// <returns></returns>
        public static CarTypeDto CarTypeDto(List<CarTypeDto> carTypes)
        {
            int answer = 1;
            bool isAnswerCorrect = false;

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
        /// <returns></returns>
        public static CustomerDto CustomerDto(List<CustomerDto> customerDto)
        {
            int answer = 1;
            bool isAnswerCorrect = false;

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
    }
}
