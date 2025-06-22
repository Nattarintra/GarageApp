using GarageConsoleApp.ConsoleIUI;
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

namespace GarageConsoleApp.Helpers
{
    internal static class VehicleInputHelper
    {

        public static Vehicle? CreateVehicle(IUI ui, string type, string reg, string color)
        {
            return type switch
            {
                "car" => new Car(reg, color, ReadPositiveInt(ui, "Wheels: "), ReadPositiveInt(ui, "Seats: ")),
                "bus" => new Bus(reg, color, ReadPositiveInt(ui, "Wheels: "), ReadPositiveInt(ui, "Seats: ")),
                "motorcycle" => new Motorcycle(reg, color, ReadPositiveInt(ui, "Wheels: "), ReadPositiveInt(ui, "Cylinder volume ")),
                "boat" => new Boat(reg, color, ReadPositiveDouble(ui, "Length (m): ")),
                "airplane" => new Airplane(reg, color, ReadPositiveInt(ui, "Number of engines: ")),
                _ => null
            };

        }
        public static int ReadPositiveInt(IUI ui, string prompt)
        {
            int value;
            do
            {
                ui.Print(prompt);
            } while (!int.TryParse(ui.GetInput(), out value) || value <= 0);
            return value;
        }

        public static double ReadPositiveDouble(IUI ui, string prompt)
        {
            double value;
            do
            {
               ui.Print(prompt);
            } while (!double.TryParse(ui.GetInput(), out value) || value <= 0);
            return value;
        }

    }
}
