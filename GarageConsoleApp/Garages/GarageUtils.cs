using GarageConsoleApp.Vehicles.AbstactClass.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace GarageConsoleApp.Garages
{
    internal partial class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        private int FindIndexByRegistration(string regNumber)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                var vehicle = slots[i];
                if (vehicle != null &&
                    vehicle.RegistrationNumber.Equals(regNumber, StringComparison.OrdinalIgnoreCase))
                {
                    return i; // Found the index of the vehicle
                }
            }
            return -1; // Vehicle not found
        }
    }
}
