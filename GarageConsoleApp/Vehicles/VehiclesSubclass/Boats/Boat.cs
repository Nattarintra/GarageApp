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

        public Boat( string reg, string color) : base(reg, color)
        {
            if (Length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Length), "Length must be greater than zero.");
            }
            Length = Length;
        }

        public override string GetDescription()
        {
            return $"Boat: {RegistrationNumber}, Color: {Color}, Length: {Length} meters";
        }
    }
}
