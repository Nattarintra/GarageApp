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
    internal class ListVehicleHandler
    {
        private readonly IUI _ui;
        private readonly Garage<Vehicle> _garage;
        public ListVehicleHandler(IUI ui, Garage<Vehicle> garage) {
            _ui = ui;
            _garage = garage;
        }

        public void Execute()
        {
            foreach (var vehicle in _garage.GetAllVehicles())
            {
                _ui.Print(vehicle.ToString());
            }
            _ui.Print($"Total vehicles in garage: {_garage.Count}");
        }
    }
}
