using GarageConsoleApp.ConsoleIUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleApp.GarageHandlers
{
    public interface IHandler
    {
        void InitializeGarage();
        void ParkingVehicle();
        void LeavingVehicle();
        void FindVehicleByRegNO();
        //void CountVehicles();
    }
}
