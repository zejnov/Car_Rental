using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCar.BusinessLayer.Dtos;
using RentalCar.BusinessLayer.Services;
using RentalCar.Cli.Commands;
using RentalCar.Cli.IoHelpers;

namespace RentalCar.Cli
{
    /// <summary>
    /// Główna logika aplikacji
    /// </summary>
    public class App
    {
        /// <summary>
        /// Zarządca komendami
        /// </summary>
        private CommandDispatcher _commandDispatcher = new CommandDispatcher();

        /// <summary>
        /// Flaga czy zakończyć program
        /// </summary>
        private bool _exit = false;

        /// <summary>
        /// Odpalenie programu
        /// </summary>
        public void Run()
        {
            //Ustawiam
            InitializeCommands();
            //Zaczynam działać w pętli
            RunExecutionLoop();
        }

        /// <summary>
        /// Ustawienie wszystkich komend
        /// </summary>
        private void InitializeCommands()
        {
            //Help i Exit zawsze na dole
            _commandDispatcher.AddCommand("AddCarType", "Add new car type", AddCarTypeAction);
            _commandDispatcher.AddCommand("AddCarForRent", "Add new car for rent", AddCarForRentAction);
            _commandDispatcher.AddCommand("AddCustomer", "Add customer to database", AddCustomerAction);
            _commandDispatcher.AddCommand("RentCar", "Renting the car to customer", RentCarAction);
            _commandDispatcher.AddCommand("ReturnCar", "Returning car to rental", ReturnCarAction);

            _commandDispatcher.AddCommand("Help", "Show all available commands", HelpAction);
            _commandDispatcher.AddCommand("Exit", "Close program", ExitAction);
        }

        /// <summary>
        /// Odpalenie działania w pętli
        /// </summary>
        private void RunExecutionLoop()
        {
            Console.WriteLine("To see available commands, type 'Help' and press Enter");

            while (!_exit)
            {
                Console.Write("\nPlease, type the command: ");
                var command = Console.ReadLine();

                if (!_commandDispatcher.Dispatch(command))
                    if (_commandDispatcher.ConstainsCommand(command))
                        Console.WriteLine($"Some unhadled error occured when executing {command} command action");
                    else
                        Console.WriteLine($"Unknow command: {command}");
            }
        }

        /// <summary>
        /// Wszystkie operacje związane z dodaniem auta 
        /// </summary>
        /// <returns>Success or no</returns>
        private bool AddCarTypeAction()
        {
            Console.Clear();

            var carTypeDto = new CarTypeDto();
            carTypeDto = UserInput.GetCarTypeDto();
            var success = CarTypeDtoServices.Add(carTypeDto);

            if (success)
            {
                Console.WriteLine("Car type added successfully");
            }
            else
            {
                Console.WriteLine("Given type of car already exists in the database");
            }
            return true;

        }

        /// <summary>
        /// Dodanie auta do wypożyczalni (z rejestracją itd...)
        /// </summary>
        /// <returns></returns>
        private bool AddCarForRentAction()
        {
            Console.Clear();

            var carForRentDto = new CarForRentDto();
            carForRentDto = UserInput.GetCarForRentDto();
            var success = CarForRentDtoServices.Add(carForRentDto);

            if (success)
            {
                Console.WriteLine("Car for rent added successfully");
            }
            else
            {
                Console.WriteLine("Given car already exists in the database");
            }
            return true;
        }

        /// <summary>
        /// Dodawanie Klienta do bazy (Imie, nazwisko, PESEL)
        /// </summary>
        /// <returns></returns>
        private bool AddCustomerAction()
        {
            Console.Clear();

            var customerDto = new CustomerDto();
            customerDto = UserInput.GetCustomerDto();
            var success = CustomerDtoServices.Add(customerDto);

            if (success)
            {
                Console.WriteLine("Customer added successfully");
            }
            else
            {
                Console.WriteLine("Given customer already exists in the database");
            }
            
            return true;
        }

        /// <summary>
        /// Łączy klienta z pojazdem w określonej dacie .Now
        /// </summary>
        /// <returns></returns>
        private bool RentCarAction()
        {
            Console.Clear();

            var rentingCar = new CarsRentedByCustomersDto();

            var choosenCustomer = ChooseFromList
                .CustomerDto(CustomerDtoServices.GetAll());

            if (choosenCustomer == null)
            {
                Console.WriteLine("There is no customers");
                return true;
            }

            rentingCar.Customer = choosenCustomer;

            var choosenCar = ChooseFromList
                .CarAvalibleForRent(CarForRentDtoServices.GetAll());

            if (choosenCar == null)
            {
                Console.WriteLine("There is no car to rent!");
                return true;
            }

            rentingCar.CarForRental = choosenCar;

            var success = CarRentedByCustomerDtoServices.Add(rentingCar);
            
            if (success)
            {
                Console.WriteLine("Renting operation ended successfully");
            }
            else
            {
                Console.WriteLine("Given customer already exists in the database");
            }
            return true;
        }

        private bool ReturnCarAction()
        {
            Console.Clear();

            //var rentingCar = new CarsRentedByCustomersDto();

            var choosenCustomer = ChooseFromList
                .CustomerDto(CustomerDtoServices.GetAll());

            if (choosenCustomer == null)
            {
                Console.WriteLine("There is no customers");
                return true;
            }
            
            var choosenRental = ChooseFromList
                .CarsRentedByCustomer(choosenCustomer.CarsRentedByCustomersList);

            Console.WriteLine("Choosen rental: {0}",Printer.StringDate(choosenRental.RentalDateTime.Date));
            

            //TODO: Proceed whith action ;D

            return true;
        }

        /// <summary>
        /// Zamykanie aplikacji
        /// </summary>
        /// <returns></returns>
        private bool ExitAction()
        {
            _exit = true;
            return true;
        }

        /// <summary>
        /// Wyświetlanie wszystkich komedn
        /// </summary>
        /// <returns></returns>
        private bool HelpAction()
        {
            Console.Clear();

            foreach (var commandActions in _commandDispatcher.GetValidCommandActions())
            {
                Printer.PrintObjectData(commandActions);
            }

            return true;
        }
    }
}
