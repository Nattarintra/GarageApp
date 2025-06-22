using GarageConsoleApp.ConsoleIUI;
using GarageConsoleApp.Garages;
using GarageConsoleApp.Helpers;
using GarageConsoleApp.Vehicles.AbstactClass;
using GarageConsoleApp.Vehicles.VehiclesSubclass.Airplanes;
using GarageConsoleApp.Vehicles.VehiclesSubclass.Boats;
using GarageConsoleApp.Vehicles.VehiclesSubclass.Buses;
using GarageConsoleApp.Vehicles.VehiclesSubclass.Cars;
using GarageConsoleApp.Vehicles.VehiclesSubclass.Motorcycles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleApp.GarageHandlers
{
    internal class GarageHandler : IHandler
    {
        private readonly Garage<Vehicle> _garage;
        private IUI _ui;
        public GarageHandler(Garage<Vehicle> garage, IUI ui) {
            _garage = garage;
            _ui = ui;
        }

        public void SetUI(IUI ui)
        {
            _ui = ui;
        }

        public void PopulateSampleGarage()
        {
            var seeder = new SampleVehicleSeeder(_ui, _garage);
            seeder.Seed();
        }

        public void HandleAddVehicle()
        {
            var adder = new AddVehicleHandler(_ui, _garage);
            adder.Execute();
        }
        public void HandleRemoveVehicle()
        {
            var remover = new RemoveVehicleHandler(_ui, _garage);
            remover.Execute();
        }
        public void HandleSearchVehicle()
        {
            var searcher = new SearchVehicleHandler(_ui, _garage);
            searcher.Execute();
        }

        public void HandleListVehicles()
        {
           var lister = new ListVehicleHandler(_ui, _garage);
            lister.Execute();

        }

        public void HandleCountByType()
        {
            var counter = new CountVehicleByTypeHandler(_ui, _garage);
            counter.Execute();   
        }

        private Vehicle? CreateVehicle(string type, string reg, string color)
        { 
            return VehicleInputHelper.CreateVehicle(_ui, type, reg, color); 
        } 
    }
}
