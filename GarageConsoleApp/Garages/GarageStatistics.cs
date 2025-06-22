using GarageConsoleApp.Vehicles.AbstactClass.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleApp.Garages
{
    internal partial class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        public IEnumerable<T> GetAllVehicles()
        {
            return this;
        }
        public int Count => slots.Count(v => v != null);

        public Dictionary<string, int> CountVehicleByType()
        {
            return this.GroupBy(v => v.GetType().Name.ToLower())
                .ToDictionary(g => g.Key, g => g.Count());
        }

    }
}
