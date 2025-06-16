using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleApp.Vehicles.AbstactClass
{
    internal abstract class Vehicle
    {

        public string RegistrationNumber { get; }
        public string Color { get; }
       
        protected Vehicle(string registrationNumber, string color)
        {
            if ( string.IsNullOrWhiteSpace(registrationNumber))
            {
                throw new ArgumentException("Registration number is required.", nameof(registrationNumber));
                
            }
            RegistrationNumber = registrationNumber;
            Color = color;
        }

        public abstract string GetDescription();

        public override string ToString()
        {
            return GetDescription();
        }

       

    }
}
