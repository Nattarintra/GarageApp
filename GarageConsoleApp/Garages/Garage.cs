using GarageConsoleApp.ConsoleIUI;
using GarageConsoleApp.Utils;
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
    
    internal partial class Garage <T> : IEnumerable<T> where T : IVehicle 
    {
        private T[] slots;
        // Initializes a new instance of the Garage class with a specified capacity.
        public Garage(int capacity) { 
        slots = new T[capacity];
        }
         
        /// <summary> Adds a vehicle to the garage if there is an available slot.</summary>
        public bool AddVehicle(T vehicle)
        {
           return  GarageAdder.TryAdd(slots, vehicle);
        }

        /// Todo: Removes the vehicle from the garage if it is already present.
        public bool RemoveVehicle(string regNumber)
        {
            int index = FindIndexByRegistration(regNumber);
            if (index >= 0)
            {
                slots[index] = default; // Remove the vehicle by setting the slot to default (null for reference types)             
                return true; // Vehicle removed successfully
            }   
            return false; // Vehicle not found

        }

        /// Todo: Search for a vehicle by its registration number.     
        public T? SearchVehicle(string regNumber)
        {
            int index = FindIndexByRegistration(regNumber);
            // Return the vehicle if found, otherwise return default (null for reference types)
            return index >= 0 ? slots[index] : default; 
  
        }

    }
}
