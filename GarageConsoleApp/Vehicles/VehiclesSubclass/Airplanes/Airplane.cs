using GarageConsoleApp.Vehicles.AbstactClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleApp.Vehicles.VehiclesSubclass.Airplanes
{
    internal class Airplane : Vehicle
    {
        public int NumberOfEngines { get; }
   
        public Airplane(string reg, string color, int numberOfEngines)
            : base(reg, color)
        {
            if (numberOfEngines <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfEngines), "Number of engines must be greater than zero.");
            }
           
            NumberOfEngines = numberOfEngines;
            
        }
        public override string GetDescription()
        {
            return $"Airplane: {RegistrationNumber}, Color: {Color}, Engines: {NumberOfEngines}";
        }
  
    }
}
