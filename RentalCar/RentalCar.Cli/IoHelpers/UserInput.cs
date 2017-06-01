using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Cli.IoHelpers
{
    /// <summary>
    /// Statyczna klasa służąca pobieraniu danych z konsoli od użytkownika
    /// </summary>
    public static class UserInput
    {
        /// <summary>
        /// Pobiera daną wartość z opisem podanym 
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
                    Console.WriteLine(message);
                    return (T) Convert.ChangeType(Console.ReadLine(), typeof(T));
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
    }
}
