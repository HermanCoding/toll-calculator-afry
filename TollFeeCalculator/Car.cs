using System;

namespace TollFeeCalculator
{
    public class Car : IVehicle
    {
        private string _name = "Car";
        private bool _tollFree = false;

        public string VehicleType => _name;
        public bool TollFreeVehicles
        {
            get => _tollFree;
            set => _tollFree = value;
        }
    }
}