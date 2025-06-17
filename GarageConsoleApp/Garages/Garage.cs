using GarageConsoleApp.Vehicles.AbstactClass.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleApp.Garages
{
    internal class Garage <T> where T : IVehicle 
    {
        private T[] slots;
        public Garage(int capacity) { 
        slots = new T[capacity];
        }

        /// Todo: Adds a vehicle to the garage if there is an available slot.
        /// Todo: Removes the vehicle from the garage if it is already present.
        /// Todo: Displays total number of vehicles in the garage.
        /// Todo: given Garage capcity when user creates a new agarage.
        /// Todo: Search for a vehicle by its registration number.
        /// 

        public bool AddVehicle(T vechicle)
        {
            // Check if the registration is existing in the garage
            foreach (var v in slots)
            {
                if (v != null && 
                    v.RegistrationNumber.Equals(vechicle.RegistrationNumber, StringComparison.OrdinalIgnoreCase))
                {
                    return false; // Vehicle already exists
                }
            }

            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i] == null)
                {
                    slots[i] = vechicle;
                    return true; // Vehicle added successfully
                }
            }
            return false; // No available slot
        }
    }
}
