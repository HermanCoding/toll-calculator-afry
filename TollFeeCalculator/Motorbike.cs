namespace TollFeeCalculator
{
    public class Motorbike : IVehicle
    {
        private string _name = "Motorbike";
        public string VehicleType => _name;

        private bool _tollFree = true;
        public bool TollFreeVehicles
        {
            get => _tollFree;
            set => _tollFree = value;
        }
    }
}
