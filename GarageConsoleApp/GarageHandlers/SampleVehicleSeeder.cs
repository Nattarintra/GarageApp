using GarageConsoleApp.ConsoleIUI;
using GarageConsoleApp.Garages;
using GarageConsoleApp.Vehicles.AbstactClass;
using GarageConsoleApp.Vehicles.VehiclesSubclass.Airplanes;
using GarageConsoleApp.Vehicles.VehiclesSubclass.Boats;
using GarageConsoleApp.Vehicles.VehiclesSubclass.Buses;
using GarageConsoleApp.Vehicles.VehiclesSubclass.Cars;
using GarageConsoleApp.Vehicles.VehiclesSubclass.Motorcycles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleApp.GarageHandlers
{
    internal class SampleVehicleSeeder
    {
        private readonly IUI _ui;
        private readonly Garage<Vehicle> _garage;

        public SampleVehicleSeeder(IUI ui, Garage<Vehicle> garage)
        {
            _ui = ui;
            _garage = garage;
        }

        public void Seed()
        { 
            _ui.Print("How many sample vehicles do you want to add? ");
            int n = int.TryParse(_ui.GetInput(), out n) ? n : 0;
            if (n > 0)
            {
                var samples = GenerateSampleVehicles(n);
                foreach (var vehicle in samples)
                {
                    _garage.AddVehicle(vehicle);
                }
                _ui.Print($"{n} sample vehicles added to the garage.");
            }
            else
            {
                _ui.Print("Invalid number. No vehicles added.");
            }
        }

        private IEnumerable<Vehicle> GenerateSampleVehicles(int count)
        {
            var list = new List<Vehicle>();
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                int option = random.Next(5);
                string reg = $"SAMPLE{i:000}";
                string color = new[] { "Red", "Blue", "Green", "Black", "White" }[random.Next(5)];

                Vehicle vehicle = option switch
                {
                    0 => new Car(reg, color, 4, random.Next(2, 6)),
                    1 => new Motorcycle(reg, color, random.Next(2, 6),random.Next(50, 201)),
                    2 => new Boat(reg, color,  random.Next(2, 6)),
                    3 => new Bus(reg, color, random.Next(2, 6),random.Next(20, 51) ),
                    _ => new Airplane(reg, color, random.Next(2, 6))
                };
                list.Add(vehicle);
            }
            return list;

        }
    }
}
