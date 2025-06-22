using GarageConsoleApp.Garages;
using GarageConsoleApp.Vehicles.AbstactClass.Interfaces;
using GarageConsoleApp.Vehicles.VehiclesSubclass.Cars;
using GarageConsoleApp.Vehicles.VehiclesSubclass.Motorcycles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsole.Tests
{
    public class GetAllVehicles
    {
        [Fact]
        public void GetAllVehicles_ShouldReturnAllVehicles()
        {
            // Arrange
            var garage = new Garage<IVehicle>(5);
            var car = new Car("AAA111", "Mazda", 4, 5);
            var motorcycle = new Motorcycle("BBB222", "Yamaha", 2, 150);
            garage.AddVehicle(car);
            garage.AddVehicle(motorcycle);

            // Act
            var actual = garage.GetAllVehicles().ToList(); 
            // Assert
            Assert.Contains(car, actual);
            Assert.Contains(motorcycle, actual);
            Assert.Equal(2, actual.Count);
        }

    }
}
