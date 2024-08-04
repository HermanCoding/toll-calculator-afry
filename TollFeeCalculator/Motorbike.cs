namespace TollFeeCalculator
{
    public class Motorbike : Vehicle
    {

        public string VehicleType()
        {
            return "Motorbike";
        }

        bool Vehicle.TollFreeVehicles()
        {
            return true;
        }
    }
}
