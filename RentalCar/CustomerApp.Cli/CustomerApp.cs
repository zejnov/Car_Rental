using System;
using System.Collections.Generic;
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
        /// Logowanie peselem, drukuje historię wypożyczeń
        /// </summary>
        /// <returns></returns>
        private bool LoginAction()
        {
            int i = 1; //do drukowania listy wypożyczeń
            var pesel = UserInput.GetCustomerPesel();

            var customer = new CustomerDto
            {
                Pesel = pesel,
            };

            var exist = CustomerDtoServices.Exist(customer);

            if (exist)
            {
            Console.WriteLine($"{pesel} found in database");

                //TODO Get CustomerDto from base,
                //Todo Print Renting history
                _loggedCustomer = customer; //"login"
                var rentalHistory = _loggedCustomer.CarsRentedByCustomersList;
                foreach (var rental in rentalHistory)
                {
                Printer.PrintOrderedList(rental, i++);
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
