// See https://aka.ms/new-console-template for more information
using GarageConsoleApp.Garages;
using GarageConsoleApp.Vehicles.AbstactClass.Interfaces;
using GarageConsoleApp.Vehicles.VehiclesSubclass.Boats;
using GarageConsoleApp.Vehicles.VehiclesSubclass.Cars;

Garage<IVehicle> garage = new Garage<IVehicle>(3);
var res =garage.Where(v => v.Color == "Red");
garage.AddVehicle(new Car("AAA111", "Mazda", 4, 5));  // Slot 0
garage.AddVehicle(new Car("BBB222", "Honda", 4, 5));  // Slot 1
garage.AddVehicle(new Car("CCC333", "Nissan", 4, 5)); // Slot 2
garage.AddVehicle(new Car("AAA111", "Mazda", 4, 5));  // Should fail - duplicate

garage.RemoveVehicle("AAA111"); // Remove first vehicle
garage.RemoveVehicle("AAA110"); // Remove first vehicle

//garage.AddVehicle(new Boat("BOAT001", "White", 2 ));

