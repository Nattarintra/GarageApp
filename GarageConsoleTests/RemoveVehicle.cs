using GarageConsoleApp.Garages;
using GarageConsoleApp.Vehicles.AbstactClass.Interfaces;
using GarageConsoleApp.Vehicles.VehiclesSubclass.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsole.Tests
{
    public class RemoveVehicle
    {
        [Fact]
        public void RemoveVehicle_ExistingRegistration_ReturnTrue()
        {
            // Arrange
            bool expected = true;
            Garage<IVehicle> garage = new Garage<IVehicle>(2);
            var car1 = new Car("AAA111", "Mazda", 4, 5);
            
            garage.AddVehicle(car1); // Add first vehicle
          
            // Act
            bool actual = garage.RemoveVehicle("AAA111"); // Try to remove first vehicle

            Assert.Equal(expected, actual);
            Assert.Equal(0, garage.Count()); // Ensure one vehicle is left


        }

        [Fact]
        public void RemoveVehicle_NonExistingRegistration_ReturnFalse()
        {
            // Arrnge
            bool expected = false;
            Garage<IVehicle> garage = new Garage<IVehicle>(2);
            var car1 = new Car("AAA111", "Mazda", 4, 5);
            var car2 = new Car("BBB222", "Honda", 4, 5);
            garage.AddVehicle(car1); // Add first vehicle
            garage.AddVehicle(car2);

            // Act
            bool actual = garage.RemoveVehicle("CCC333"); // Try to remove a non-existing vehicle

            // Assert
            Assert.Equal(expected, actual);
            Assert.Equal(2, garage.Count()); // Ensure both vehicles are still present

        }
    }
}
