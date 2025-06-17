using System.Diagnostics.Metrics;
using GarageConsoleApp.Garages;
using GarageConsoleApp.Vehicles.AbstactClass.Interfaces;
using GarageConsoleApp.Vehicles.VehiclesSubclass.Cars;

namespace GarageConsoleTests
{
    public class AddVehicle
    {
        

        [Fact]
        public void AddVehicle_UniqRegistration_ReturnTrue()
        {
            // Arrange
            bool expected = true;

            Garage<IVehicle> garage = new Garage<IVehicle>(3);

            var car = new Car("AAA111", "Mazda", 4, 5);
            

            // Act
            //bool actual = garage.AddVehicle(new Car("AAA111", "Mazda", 4, 5));
            bool actual = garage.AddVehicle( car);

            // Assert
            Assert.Equal(expected, actual);
            Assert.Equal(1, garage.Count()); // Ensure only one vehicle is present
            Assert.Equal(car, garage.FirstOrDefault(v => v.RegistrationNumber == "AAA111")); // Ensure the vehicle is still there

        }

        [Fact]
        public void AddVehicle_DuplicateRegistration_ReturnFalse()
        {
            // Arrange
            bool expected = false;
            
            Garage<IVehicle> garage = new Garage<IVehicle>(3);
            var car = new Car("AAA111", "Mazda", 4, 5);
            garage.AddVehicle(car); // Add first vehicle
            
            // Act
            bool actual = garage.AddVehicle(car); // Try to add duplicate
            
            // Assert
            Assert.Equal(expected, actual);
            Assert.Equal(1, garage.Count());
            Assert.Equal(car, garage.FirstOrDefault(v => v.RegistrationNumber == "AAA111"));

        }

        [Fact]
        public void AddVehicle_FullGarage_ReturnFalse()
        {
            // Arrange
            bool expected = false; // คาดหวังว่าจะ return false เมื่อเต็มแล้ว
            var garage = new Garage<IVehicle>(2); // มีที่จอดได้แค่ 2 คัน
            var car1 = new Car("AAA111", "Mazda", 4, 5);
            var car2 = new Car("BBB222", "Toyota", 4, 5);

            garage.AddVehicle(car1); // คันที่ 1
            garage.AddVehicle(car2); // คันที่ 2 (เต็มแล้ว)

            var newCar = new Car("CCC333", "Honda", 4, 5); // คันใหม่ที่จะลองเพิ่ม

            // Act
            bool actual = garage.AddVehicle(newCar); // พยายามเพิ่มรถคันที่ 3

            // Assert
            Assert.Equal(expected, actual); // ควร return false เพราะเต็มแล้ว
            Assert.Equal(2, garage.Count()); // ยังมีแค่ 2 คันใน garage
            Assert.Null(garage.FirstOrDefault(v => v.RegistrationNumber == "CCC333")); // คันใหม่ไม่ควรอยู่ใน garage
        }

    }
}
