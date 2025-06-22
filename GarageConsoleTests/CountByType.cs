using GarageConsoleApp.Garages;
using GarageConsoleApp.Vehicles.AbstactClass.Interfaces;
using GarageConsoleApp.Vehicles.VehiclesSubclass.Airplanes;
using GarageConsoleApp.Vehicles.VehiclesSubclass.Cars;
using GarageConsoleApp.Vehicles.VehiclesSubclass.Motorcycles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsole.Tests
{
    public class CountByType
    {
        [Fact]
        public void CountByType_ShouldReturnCorrectCounts()
        {
            // Arrange
            var garage = new Garage<IVehicle>(5);
          
            garage.AddVehicle(new Car("AAA111", "Green", 4, 5));
            garage.AddVehicle(new Car("BBB222", "Red", 4, 5));
            garage.AddVehicle(new Motorcycle("CCC333", "Black", 2, 150));
            garage.AddVehicle(new Airplane("DDD444", "White", 2));

            // Act
            var actual = garage.CountVehicleByType();
           

            // Assert
            Assert.Equal(2, actual["car"]);
            Assert.Equal(1, actual["motorcycle"]);
            Assert.Equal(1, actual["airplane"]);
            Assert.Equal(3, actual.Keys.Count); // should have only 3 types car, motorcycle, airplane
        }
    }
}
