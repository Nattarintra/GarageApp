using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleApp.Vehicles.AbstactClass
{
    
    internal abstract class WheeledVehicle : Vehicle
    {
        public int Wheels { get; }
        protected WheeledVehicle(string registrationNumber, string color, int wheels) : base(registrationNumber, color)
        {
            if (wheels <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(wheels));   
            }
            Wheels = wheels;

        }
    }
}
