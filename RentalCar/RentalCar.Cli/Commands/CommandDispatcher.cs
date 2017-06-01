using System;
using System.Collections.Generic;

namespace RentalCar.Cli.Commands
{
    public class CommandDispatcher
    {
        /// <summary>
        /// Lista dostępnych komend
        /// </summary>
        private List<CommandAction> _validCommands = new List<CommandAction>();

        /// <summary>
        /// Dodanie nowej komendy do listy
        /// </summary>
        /// <param name="command"></param>
        /// <param name="description"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool AddCommand(string command, string description, Func<bool> action)
        {
            if (ConstainsCommand(command))
                return false;

            _validCommands.Add(new CommandAction(command, description, action));
            return true;
        }

        /// <summary>
        /// Sprawdzenie czy dana komenda istnieje
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool ConstainsCommand(string command)
        {
            return (FindCommandAciotn(command) != null);
        }

        /// <summary>
        /// Odpalenie danej komendy
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool Dispatch(string command)
        {
            CommandAction commandAction = FindCommandAciotn(command);

            if (commandAction != null)
                return commandAction.ExecuteCommandAction();

            return false;
        }

        /// <summary>
        /// Pobranie listy dostępnych komend
        /// </summary>
        /// <returns></returns>
        public List<CommandAction> GetValidCommandActions()
        {
            return _validCommands;
        }

        /// <summary>
        /// Szukanie komendy
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private CommandAction FindCommandAciotn(string command)
        {
            return _validCommands.Find(p => p.Command == command);
        }
    }
}
