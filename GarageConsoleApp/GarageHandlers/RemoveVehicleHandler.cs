using GarageConsoleApp.ConsoleIUI;
using GarageConsoleApp.Garages;
using GarageConsoleApp.Vehicles.AbstactClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleApp.GarageHandlers
{
    internal class RemoveVehicleHandler
    {
        private readonly IUI _ui;
        private readonly Garage<Vehicle> _garage;
        public RemoveVehicleHandler(IUI ui, Garage<Vehicle> garage) { 
            _ui = ui;
            _garage = garage;
        }

        public void Execute()
        {
            _ui.Print("Enter registration number to remove: ");
            var reg = _ui.GetInput();
            var removedVehicle = _garage.RemoveVehicle(reg);

            if(removedVehicle != null)
                _ui.Print($"Removed successfully: {removedVehicle}");
            else
                _ui.Print("Vehicle not found.");
        }
    }
}
