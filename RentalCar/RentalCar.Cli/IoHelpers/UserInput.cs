using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCar.BusinessLayer.Dtos;
using RentalCar.BusinessLayer.Services;

namespace RentalCar.Cli.IoHelpers
{
    /// <summary>
    /// Statyczna klasa służąca pobieraniu danych z konsoli od użytkownika
    /// </summary>
    public static class UserInput
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

        /// <summary>
        /// Pobieranie od urzytkownika CarTypeDto
        /// </summary>
        /// <returns>CarTypeDto</returns>
        public static CarTypeDto GetCarTypeDto()
        {
            var carTypeDto = new CarTypeDto();
            carTypeDto.Mark = GetData<string>("Provide car mark: ");
            carTypeDto.Model = GetData<string>("Provide car model: ");
            carTypeDto.PricePerDay = GetData<int>("Provide price per day: ");

            return carTypeDto;
        }

        /// <summary>
        /// Pobieranie danych do konkretnego pojazdu
        /// </summary>
        /// <returns></returns>
        public static CarForRentDto GetCarForRentDto()
        {
            var carForRentDto = new CarForRentDto();
            carForRentDto.RegistrationNumber = GetData<string>("Provide registration number: ");
            var carTypeList = CarTypeDtoServices.GetAll();
                carForRentDto.TypeOfCar = ChooseFromList.CarTypeDto(carTypeList);
            
            return carForRentDto;
        }
    }
}
