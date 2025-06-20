using GarageConsoleApp.Vehicles.AbstactClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleApp.Vehicles.VehiclesSubclass.Motorcycles
{
    internal class Motorcycle : WheeledVehicle
    {
        public int CylinderVolume { get; }
        public Motorcycle(string reg, string color, int wheels, int cylinderVolume) 
            : base(reg, color, wheels)
        {
            if (wheels <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(wheels), "Number of wheels must be greater than zero.");
            }
            CylinderVolume = cylinderVolume;
        }
        public override string GetDescription()
        {
            return $"Motorcycle: {RegistrationNumber}, Color: {Color}, Wheels: {Wheels}, Has cylinder volume: {CylinderVolume}";
        }
    }
}
