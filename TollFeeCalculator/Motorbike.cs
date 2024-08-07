namespace TollFeeCalculator
{
    public class Motorbike : IVehicle
    {
        private string _name = "Motorbike";
        private bool _tollFree = true;

        public string VehicleType => _name;
        public bool TollFreeVehicles
        {
            get => _tollFree;
            set => _tollFree = value;
        }
    }
}
