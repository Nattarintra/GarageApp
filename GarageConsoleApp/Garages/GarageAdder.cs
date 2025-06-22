using GarageConsoleApp.Vehicles.AbstactClass;
using GarageConsoleApp.Vehicles.AbstactClass.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleApp.Garages
{
    internal static class GarageAdder
    {
        public static bool TryAdd<T>(T[] slots, T vehicle) where T : IVehicle
        {
            int? firstEmptySlot = null;

            for (int i = 0; i < slots.Length; i++)
            {
                var current = slots[i];

                if (current != null &&
                   current.RegistrationNumber
                   .Equals(vehicle.RegistrationNumber, StringComparison.OrdinalIgnoreCase))
                {
                    return false; // Vehicle already exists
                }

                if (current == null && firstEmptySlot == null)
                {
                    firstEmptySlot = i; // Found the first empty slot
                }

            }
            if (firstEmptySlot != null)
            {
                slots[firstEmptySlot.Value] = vehicle;
                return true; // Vehicle added successfully
            }
            return false; // No available slot

        }
    }
}
