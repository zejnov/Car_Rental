using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCar.Cli.Commands;

namespace RentalCar.Cli.IoHelpers
{
    public static class Printer
    {
        public static void PrintObjectData(CommandAction command)
        {
            Console.WriteLine($"{command.Command} - {command.Description}");
        }
    }
}
