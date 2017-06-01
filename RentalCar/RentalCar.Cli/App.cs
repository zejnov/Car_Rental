using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCar.BusinessLayer.Dtos;
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
           // _commandDispatcher.AddCommand(GetCar)
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
            var carTypeDto = new CarTypeDto();
            carTypeDto = IoHelpers.UserInput.GetCarTypeDto();


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
