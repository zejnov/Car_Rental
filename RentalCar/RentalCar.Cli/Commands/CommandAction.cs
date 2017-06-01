using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Cli.Commands
{
    class CommandAction
    {
        public string Command { get; private set; }
        public string Description { get; private set; }

        private Func<bool> _action;

        public CommandAction (string command, string description, Func<bool> action)
        {
            Command = command;
            Description = description;
            _action = action;
        }

        public bool ExecuteCommandAction()
        {
            return _action();
        }
    }
}
