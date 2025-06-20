using GarageConsoleApp.Vehicles.AbstactClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleApp.Vehicles.VehiclesSubclass.Boats
{
    internal class Boat : Vehicle
    {
        public double Length { get; }

        public Boat( string reg, string color, double length) : base(reg, color)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Length must be greater than zero.");
            }

            Length = length;
        }

        public override string GetDescription()
        {
            return $"Boat: {RegistrationNumber}, Color: {Color}, Length: {Length} meters";
        }
    }
}
