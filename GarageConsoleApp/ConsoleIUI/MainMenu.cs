using GarageConsoleApp.GarageHandlers;
using GarageConsoleApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleApp.ConsoleIUI
{
    internal class MainMenu : IUI
    {
        private readonly IHandler _handler;

        public MainMenu(IHandler handler)
        {
            _handler = handler;
        }

        public void ShowMainMenu()
        {
            var navigator = new MenuNavigator(this, _handler);
            navigator.RunMenuNavigator();
        }

        public void Print(string message)
        {
            ConsoleUI.Print(message);
        }

        public string GetInput()
        {
            return ConsoleUI.GetInput();
        }
    }
}