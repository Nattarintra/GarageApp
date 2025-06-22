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
   
    internal class CountVehicleByTypeHandler
    {
        private readonly IUI _ui;
        private readonly Garage<Vehicle> _garage;
        public CountVehicleByTypeHandler(IUI uI, Garage<Vehicle> garage) {
            _ui = uI;
            _garage = garage;
        }

        public void Execute()
        {
            var typeCount = _garage.CountVehicleByType();
            if (typeCount.Count == 0)
            {
                _ui.Print("No vehicles in the garage.");
                return;
            }
            _ui.Print("Vehicle counts by type:");
            foreach (var kvp in typeCount)
            {
                _ui.Print($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
