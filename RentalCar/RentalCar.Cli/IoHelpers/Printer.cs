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
        public static void PrintObjectData(CommandAction command)
        {
            Console.WriteLine($"{command.Command} - {command.Description}");
        }

        public static void PrintOrderedList(CarTypeDto courseMember, int ordinal)
        {
            Console.WriteLine($"{ordinal}. {courseMember.Mark} {courseMember.Model} {courseMember.PricePerDay}zl/day");
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
