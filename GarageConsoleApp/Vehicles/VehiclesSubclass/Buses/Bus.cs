using GarageConsoleApp.Vehicles.AbstactClass;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleApp.Vehicles.VehiclesSubclass.Buses
{
    internal class Bus : WheeledVehicle
    {
        public int NumberOfSeats { get; } = 50; // Default value for a bus
        public Bus( string reg, string color, int wheels, int seats) : base(reg, color, wheels) 
        {
            if (wheels <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(wheels), "Number of wheels must be greater than zero.");
            }

        }

        public override string GetDescription()
        {
           return $"Bus: {RegistrationNumber}, Color: {Color}, Wheels: {Wheels}, Seats: {NumberOfSeats}";
        }
    }
}
