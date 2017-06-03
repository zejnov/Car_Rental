using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCar.BusinessLayer.Services;

namespace CustomerApp.Cli.IoHelpers
{
    class UserInput
    {
        /// <summary>
        /// Generyczne pobieranie
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public static T GetData<T>(string message)
        {
            while (true)
            {
                try
                {
                    Console.Write(message + " ");
                    return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR! You didnt gave anything, ty again");
                }
                catch (Exception)
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR! Something went wrong, try again");
                }
            }
        }

        public static long GetCustomerPesel()
        {
            var pesel = UserInput.GetData<long>("Provide PESEL to proceed: ");
            while (!CustomerDtoServices.CheckPesel(pesel))
            {
                Console.WriteLine("You provide wrong PESEL, try again");
                pesel = UserInput.GetData<long>("Provide PESEL: ");
            }

            return pesel;
        }
    }
}
