using GarageConsoleApp.GarageHandlers;
using GarageConsoleApp.Utils;

namespace GarageConsoleApp.ConsoleIUI
{
    internal class MenuLoop
    {
        private readonly IUI _ui;
        private readonly IHandler _handler;

        public MenuLoop(IUI ui, IHandler handler)
        {
            _ui = ui;
            _handler = handler;
        }

        public void RunLoop()
  
        {
            do
            {
                _ui.Print("");
                _ui.Print("Enter your choice: ");
                string choice = _ui.GetInput();

                switch (choice)
                {
                    case "1":
                        _handler.PopulateSampleGarage();
                        break;
                    case "2":
                        _handler.HandleAddVehicle();
                        break;
                    case "3":
                        _handler.HandleRemoveVehicle();                      
                        break;
                    case "4":
                        _handler.HandleSearchVehicle();                      
                        break;
                    case "5":
                        _ui.Print("Logic to list all vehicles");
                        break;
                    case "0":
                        _ui.Print("Exiting the system. Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        _ui.Print("Invalid choice, please try again.");
                        break;
                }
            } while (true);
        }
    }
}
