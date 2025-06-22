using GarageConsoleApp.ConsoleIUI;
using GarageConsoleApp.Garages;
using GarageConsoleApp.Helpers;
using GarageConsoleApp.Vehicles.AbstactClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleApp.GarageHandlers
{
    internal class AddVehicleHandler
    {
        private readonly IUI _ui;
        private readonly Garage<Vehicle> _garage;
        public AddVehicleHandler(IUI ui, Garage<Vehicle> garage)
        {
            _ui = ui;
            _garage = garage;
        }

        public void Execute()
        {
            _ui.Print("Enter vehicle type (Car, Motorcycle, Bus, Boat, Airplane): ");
            string type = _ui.GetInput().ToLower();

            _ui.Print("Enter registration number: ");
            string reg = _ui.GetInput();

            _ui.Print("Color: ");
            string color = _ui.GetInput();

            var vehicle = VehicleInputHelper.CreateVehicle(_ui,type, reg, color);

            if ( vehicle == null)
            {
                _ui.Print("Unsupported type");
                return;
            }

            if (_garage.AddVehicle(vehicle))
            {
                _ui.Print("Added: " + vehicle);
            }
            else
            {
                _ui.Print("Cannot add vehicle: garage is full or vehicle already exists.");
            }


        }
    }
}
