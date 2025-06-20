using GarageConsoleApp.GarageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleApp.ConsoleIUI
{
    internal class MenuNavigator
    {
        private readonly MenuDisplay _display;
        private readonly MenuLoop _loop;

        public MenuNavigator(IUI ui, IHandler handler)
        {
            _display = new MenuDisplay(ui);
            _loop = new MenuLoop(ui, handler);
        }

        public void RunMenuNavigator()
        {
            _display.ShowMenu();
            _loop.RunLoop();
        }
    }
}
