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
    
    internal class Garage <T> : IEnumerable<T> where T : IVehicle 
    {
        private T[] slots;
        // Initializes a new instance of the Garage class with a specified capacity.
        public Garage(int capacity) { 
        slots = new T[capacity];
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
                    ConsoleUI.Print(vehicle.RegistrationNumber + " is already exist.");
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
               // Console.WriteLine("Successfully add " + firstEmptySlot.Value);
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
                ConsoleUI.Print($"Removed successfully {regNumber} from the garage. ");
                return true; // Vehicle removed successfully
            }
            ConsoleUI.Print("Vehicle not found or could not be removed."); ;
            return false; // Vehicle not found

        }

       
        /// Todo: Search for a vehicle by its registration number.
        
        public T? SearchVehicle(string regNumber)
        {
            int index = FindIndexByRegistration(regNumber);
            if (index >= 0)
            {
                Console.WriteLine(regNumber + " is parking with us at index " + index);
                return slots[index]; // Return the vehicle if found
            }
            Console.WriteLine(regNumber + " Not found");
            return default; // Return default value (null for reference types) if not found
        }

        /// Todo: Displays total number of vehicles in the garage.
        /// 
        public void CountVehicles()
        {
            int count = 0;
            foreach (var vehicle in slots)
            {
                if (vehicle != null)
                {
                    count++; // Increment count for each non-null vehicle
                } 
            }
            Console.WriteLine("Total vehicles in the garage: " + count);
            //return count; // Return the total count of vehicles
        }
        //ListAllVehicle()

        // CountVehicleByType()


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
