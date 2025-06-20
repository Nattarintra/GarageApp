// See https://aka.ms/new-console-template for more information
using GarageConsoleApp.ConsoleIUI;
using GarageConsoleApp.GarageHandlers;
using GarageConsoleApp.Garages;
using GarageConsoleApp.Vehicles.AbstactClass;


Garage<Vehicle> garage = new Garage<Vehicle>(3);  // ✅ ใช้ Vehicle ไม่ใช่ IVehicle
var handler = new GarageHandler(garage, null);    // โอเค ส่ง null ไปก่อน
var mainMenu = new MainMenu(handler);             // ใช้ handler ที่สร้างไว้
handler.SetUI(mainMenu);                          // เชื่อม UI กับ handler
mainMenu.ShowMainMenu();





