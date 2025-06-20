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
        public void InitializeGarage()
        {
            _ui.Print("How many sample do you want? ");
            int n = int.TryParse(_ui.GetInput(), out n) ? n : 0;
            if (n >= 0)
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
                _ui.Print("Invalid number of samples. No vehicles added.");
            }
           
        }
        private IEnumerable<Vehicle> GenerateSampleVehicles(int count)
        {
            var list = new List<Vehicle>();
            var random = new Random();
            for (int i = 0;  i < count; i++)
            {
                switch(random.Next(5)) 
                {
                    case 0:
                        list.Add(new Car($"CAR{i:000}", "Red", 4, random.Next(2, 6)));
                        break;
                    case 1:
                        list.Add(new Car($"CAR{i:000}", "Blue", 4, random.Next(2, 6)));
                        break;
                    case 2:
                        list.Add(new Car($"CAR{i:000}", "Green", 4, random.Next(2, 6)));
                        break;
                    case 3:
                        list.Add(new Car($"CAR{i:000}", "Black", 4, random.Next(2, 6)));
                        break;
                    default :
                        list.Add(new Car($"CAR{i:000}", "White", 4, random.Next(2, 6)));
                        break;
                       
                }
                
            }
            return list;
        }

        public void ParkingVehicle()
        {
            _ui.Print("Enter vehicle type (Car, Bus, Motorcycle, Boat, Airplane): ");
            var type = _ui.GetInput().ToLower();

            _ui.Print("Enter registration number: ");
            var reg = _ui.GetInput();

            _ui.Print("Color: ");
            var color = _ui.GetInput();

            Vehicle vehicle;
            switch (type)
            {
                case "car":
                    int wheelsCar = ReadPositiveInt("Wheels: ");
                    int seats = ReadPositiveInt("Seats: ");
                    vehicle = new Car(reg, color, wheelsCar, seats);
                    break;

                case "bus":
                    int wheelsBus = ReadPositiveInt("Wheels: ");
                    int busSeats = ReadPositiveInt("Seats: ");
                    vehicle = new Bus(reg, color, wheelsBus, busSeats);
                    break;

                case "motorcycle":
                    int wheelsMoto = ReadPositiveInt("Wheels: ");
                    int cc = ReadPositiveInt("Cylinder volume: ");
                    vehicle = new Motorcycle(reg, color, wheelsMoto, cc);
                    break;

                case "boat":
                    double length;
                    string input;
                    do
                    {
                        _ui.Print("Length (m): ");
                        input = _ui.GetInput();
                    } while (!double.TryParse(input, out length) || length <= 0);

                    vehicle = new Boat(reg, color, length);
                    break;

                case "airplane":
                    int engines = ReadPositiveInt("Number of engines: ");
                    vehicle = new Airplane(reg, color, engines);
                    break;

                default:
                    _ui.Print("Unsupported vehicle type. Please try again.");
                    return;
            }

            if (_garage.AddVehicle(vehicle))
                _ui.Print($"Added: {vehicle}");
            // check if garage is full or vehicle already exists
            /*else if (_garage.IsFull())
                _ui.Print("Cannot add vehicle: garage is full.");
            else if (_garage.SearchVehicle(reg) != null)
                _ui.Print("Cannot add vehicle: duplicate registration number.");*/
            else
                _ui.Print("Cannot add vehicle: garage full or duplicate registration.");
        }

        private int ReadPositiveInt(string prompt)
        {
            int value;
            do
            {
                _ui.Print(prompt);
            } while (!int.TryParse(_ui.GetInput(), out value) || value <= 0);
            return value;
        }
        // Remove a vehicle by registration number
        public void LeavingVehicle()
        {
            _ui.Print("Enter registration number to remove: ");
            var reg = _ui.GetInput();
            var vehicle = _garage.RemoveVehicle(reg);         
        }

        // Search for a vehicle by registration number
        public void FindVehicleByRegNO()
        { _ui.Print("Enter registration number to search: ");
          var reg = _ui.GetInput();
            var vehicle = _garage.SearchVehicle(reg);

        }


    }

}
