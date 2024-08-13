using System;

namespace TollFeeCalculator
{
    public class Car : IVehicle
    {
        private string _regnumber;
        private bool _tollFree = false;

        public Car(string regnumber)
        {
            _regnumber = regnumber;
        }

        public string VehicleType => "Car";
        public bool IsTollFreeVehicle
        {
            get => _tollFree;
            set => _tollFree = value;
        }
        public string RegistrationNumber 
        { 
            get => _regnumber; 
            set => _regnumber = value; 
        }

        // TODO
        // public TollHistory TollHistory { get; set; } = new TollHistory();
    }
}