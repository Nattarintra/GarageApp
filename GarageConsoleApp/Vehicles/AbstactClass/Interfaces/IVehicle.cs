using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleApp.Vehicles.AbstactClass.Interfaces
{
    internal interface IVehicle
    {
        string RegistrationNumber { get; }
        string Color { get; }
    }
}
