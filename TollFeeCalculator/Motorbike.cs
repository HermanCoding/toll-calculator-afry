using System;

namespace TollFeeCalculator
{
    public class Motorbike : IVehicle
    {
        private string _name = "Motorbike";
        private string _regnumber;
        private bool _tollFree = true;

        public Motorbike(string regnumber)
        {
            _regnumber = regnumber;
        }

        public string VehicleType => _name;
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

    }
}
