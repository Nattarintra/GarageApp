using GarageConsoleApp.Vehicles.AbstactClass.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleApp.Garages
{
    internal partial class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in slots)
            {
                if (vehicle != null)
                {
                    yield return vehicle;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
