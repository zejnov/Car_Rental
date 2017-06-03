using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerApp.Cli.IoHelpers;
using CustomerApp.Commands;
using RentalCar.BusinessLayer.Dtos;
using RentalCar.BusinessLayer.Services;

namespace CustomerApp.Cli
{
    /// <summary>
    /// Główna logika aplikacji
    /// </summary>
    public class CustomerApp
    {
        /// <summary>
        /// Zarządca komendami
        /// </summary>
        private CommandDispatcher _commandDispatcher = new CommandDispatcher();

        /// <summary>
        /// przechowywanie zalogowanego klienta
        /// </summary>
        private CustomerDto _loggedCustomer = new CustomerDto();

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
            Console.WriteLine("Welcome to Customer App");
            RunExecutionLoop();
        }

        /// <summary>
        /// Ustawienie wszystkich komend
        /// </summary>
        private void InitializeCommands()
        {
            //Help i Exit zawsze na dole
            _commandDispatcher.AddCommand("Login", "Login with customer Pesel", LoginAction);
            _commandDispatcher.AddCommand("Change", "Change your name and surname", ChangeDataAction);
            _commandDispatcher.AddCommand("Logout", "Longout from system", LogoutAction);
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
        /// Zmiana danych urzytkownika
        /// </summary>
        /// <returns></returns>
        private bool ChangeDataAction()
        {
            if (_loggedCustomer == null)
            {
                Console.WriteLine("You must be logged at first!");
                return true;
            }

            var updatedCustomer = new CustomerDto();
            updatedCustomer.Name = UserInput.GetData<string>("New name");
            updatedCustomer.Surname = UserInput.GetData<string>("New surname");

            if (CustomerDtoServices.UpadtePersonalData(_loggedCustomer, updatedCustomer))
            {
                Console.WriteLine("Update successful");
                _loggedCustomer.Name = updatedCustomer.Name;
                _loggedCustomer.Surname = updatedCustomer.Surname;
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }

            return true;
        }

        /// <summary>
        /// Logowanie peselem, drukuje historię wypożyczeń
        /// </summary>
        /// <returns></returns>
        private bool LoginAction()
        {
            int i = 1; //do drukowania listy wypożyczeń
            var pesel = UserInput.GetCustomerPesel();

            var customer = CustomerDtoServices.Get(pesel);

            if (customer != null)
            {
                _loggedCustomer = customer; //"login"

                var rentalHistory = customer.CarsRentedByCustomersList;

                if (rentalHistory.Count == 0)
                {
                    Console.WriteLine("There is no history");
                }

                foreach (var rental in rentalHistory)
                {
                    Printer.PrintOrderedList(rental, i++);
                    Console.WriteLine();
                }

            }
            else
            { 
                Console.WriteLine($"{pesel} not found in database");
            }

            return true;
        }

        /// <summary>
        /// Wylogowanie się klienta z aplikacji
        /// </summary>
        /// <returns></returns>
        private bool LogoutAction()
        {
            _loggedCustomer = null;
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
