using GarageConsoleApp.Vehicles.AbstactClass.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("GarageConsole.Tests")] // Allow unit tests to access internal members
namespace GarageConsoleApp.Garages
{
    
    internal class Garage <T> : IEnumerable<T> where T : IVehicle 
    {
        private T[] slots;
        // Initializes a new instance of the Garage class with a specified capacity.
        public Garage(int capacity) { 
        slots = new T[capacity];
        }

        /// Todo: Displays total number of vehicles in the garage.
       
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
        /// <summary> Adds a vehicle to the garage if there is an available slot.</summary>

        public bool AddVehicle(T vechicle)
        {

            int? firstEmptySlot = null;

            for (int i = 0; i < slots.Length; i++)
            {
                var vehicle = slots[i];

                if (vehicle != null &&
                   vehicle.RegistrationNumber.Equals(vechicle.RegistrationNumber, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(vehicle.RegistrationNumber + " is already exist.");
                    return false; // Vehicle already exists
                }

                if (vehicle == null && firstEmptySlot == null)
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

        /// Todo: Removes the vehicle from the garage if it is already present.

        public bool RemoveVehicle(string regNumber)
        {
  
            int index = FindIndexByRegistration(regNumber);
            if (index >= 0)
            {
                slots[index] = default; // Remove the vehicle by setting the slot to default (null for reference types)
                Console.WriteLine("Successfully removed " + regNumber);
                return true; // Vehicle removed successfully
            }
                Console.WriteLine( regNumber + " Not found");
            return false; // Vehicle not found

        }

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

        /// Todo: Search for a vehicle by its registration number.
        



    }
}
