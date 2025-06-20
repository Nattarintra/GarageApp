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
    public class SearchVehicle
    {
        [Fact]
        public void SearchVehicle_ExistingRegistration_ReturnVehicle()
        {
            // Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(2);
            var expected = new Car("AAA111", "Mazda", 4, 5);
            garage.AddVehicle(expected); // Add first vehicle


            // Act
            var actual = garage.SearchVehicle("AAA111"); // Try to search for the vehicle

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void SearchVehicle_NonExistingRegistration_ReturnNull()
        {
            // Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(2);           
            garage.AddVehicle(new Car("BBB222", "Honda", 4, 5)); 

            var expected = null as IVehicle; // Expecting null since vehicle does not exist

            // Act
            var actual = garage.SearchVehicle("AAA111"); // Try to search for a non-existing vehicle

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
