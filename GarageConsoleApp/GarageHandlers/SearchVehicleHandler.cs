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
    internal class SearchVehicleHandler
    {
        private readonly IUI _ui;
        private readonly Garage<Vehicle> _garage;
        public SearchVehicleHandler(IUI ui, Garage<Vehicle> garage ) 
        { 
            _ui = ui;
            _garage = garage;
        }

        public void Execute()
        {
            _ui.Print("Enter registration number to search: ");
            var reg = _ui.GetInput();
            var vehicle = _garage.SearchVehicle(reg);

            if (vehicle != null)
            {
                _ui.Print($"Found vehicle: {vehicle}");
            }
            else
            {
                _ui.Print($"Vehicle with registration number {reg} not found.");
            }
        }
    }
}
