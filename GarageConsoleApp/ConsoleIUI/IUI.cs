using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleApp.ConsoleIUI
{
    public interface IUI
    {
        void ShowMainMenu();
        void Print(string message);
        string GetInput();


    }
}
