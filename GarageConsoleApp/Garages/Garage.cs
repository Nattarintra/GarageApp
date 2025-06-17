using GarageConsoleApp.Vehicles.AbstactClass.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("GarageConsole.Tests")] // Allow unit tests to access internal members
namespace GarageConsoleApp.Garages
{
    
    internal class Garage <T> : IEnumerable<T> where T : IVehicle 
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

            int? firstEmptySlot = null;

            for (int i = 0; i < slots.Length; i++)
            {
                var v = slots[i];
                if (v != null &&
                   v.RegistrationNumber.Equals(vechicle.RegistrationNumber, StringComparison.OrdinalIgnoreCase))
                {
                    return false; // Vehicle already exists
                }

                if (v == null && firstEmptySlot == null)
                {
                    firstEmptySlot = i; // Found the first empty slot
                }
   
            }
            if  (firstEmptySlot != null)
            {
                slots[firstEmptySlot.Value] = vechicle;
                Console.WriteLine("Successfully add " + firstEmptySlot.Value);
                return true; // Vehicle added successfully
            }
            return false; // No available slot
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in slots)
            {
                if (vehicle != null)
                {
                    yield return vehicle;
                }
            }   
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
