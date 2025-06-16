using GarageConsoleApp.Vehicles.AbstactClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleApp.Vehicles.VehiclesSubclass.Cars
{
    internal class Car : WheeledVehicle
    {
        public int NumberOfSeats { get; }
        public Car(string reg, string color, int wheels, int numberOfSeats) 
            : base(reg, color, wheels)
        {
            if (numberOfSeats <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfSeats), "Number of seats must be greater than zero.");
            }
            NumberOfSeats = numberOfSeats;
        }

        public override string GetDescription()
        {
           return $"Car: {RegistrationNumber}, Color: {Color}, Wheels: {Wheels}, Seats: {NumberOfSeats}";
        }
    }
}
