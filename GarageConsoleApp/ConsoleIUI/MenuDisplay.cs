using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleApp.ConsoleIUI
{
    internal class MenuDisplay
    {
        private readonly IUI _ui;

        public MenuDisplay(IUI ui)
        {
            _ui = ui;
        }

        public void ShowMenu()
        {
            _ui.Print("Welcome to the Garage Management System!");
            _ui.Print("Please choose an option:");
            _ui.Print("1. Create a new Garage");
            _ui.Print("2. Add Vehicle");
            _ui.Print("3. Remove Vehicle");
            _ui.Print("4. Search Vehicle");
            _ui.Print("5. List Vehicles");
            _ui.Print("6. Show Vehicle types");
            _ui.Print("0. Exit");
        }
    }
}
