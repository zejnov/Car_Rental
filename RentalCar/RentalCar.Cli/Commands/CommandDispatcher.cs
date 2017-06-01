using System;
using System.Collections.Generic;

namespace RentalCar.Cli.Commands
{
    class CommandDispatcher
    {
        private List<CommandAction> _validCommands = new List<CommandAction>();

        public bool AddCommand(string command, string description, Func<bool> action)
        {
            if (ConstainsCommand(command))
                return false;

            _validCommands.Add(new CommandAction(command, description, action));
            return true;
        }

        public bool ConstainsCommand(string command)
        {
            return (FindCommandAciotn(command) != null);
        }

        public bool Dispatch(string command)
        {
            CommandAction commandAction = FindCommandAciotn(command);

            if (commandAction != null)
                return commandAction.ExecuteCommandAction();

            return false;
        }

        public List<CommandAction> GetValidCommandActions()
        {
            return _validCommands;
        }

        private CommandAction FindCommandAciotn(string command)
        {
            return _validCommands.Find(p => p.Command == command);
        }
    }
}
