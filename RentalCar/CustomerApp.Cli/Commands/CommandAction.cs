using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Commands
{
    /// <summary>
    /// Klasa przetrzymująca pojedyńczą komendę
    /// </summary>
    public class CommandAction
    {
        /// <summary>
        /// Tekst, który wywołuje komendę
        /// </summary>
        public string Command { get; private set; }

        /// <summary>
        /// Opis komendy
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Akcja która jest wywyoływana
        /// </summary>
        private Func<bool> _action;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="command"></param>
        /// <param name="description"></param>
        /// <param name="action"></param>
        public CommandAction (string command, string description, Func<bool> action)
        {
            Command = command;
            Description = description;
            _action = action;
        }

        /// <summary>
        /// Egzekucja
        /// </summary>
        /// <returns></returns>
        public bool ExecuteCommandAction()
        {
            return _action();
        }
    }
}
