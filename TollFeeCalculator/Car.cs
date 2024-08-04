using System;

namespace TollFeeCalculator
{
    public class Car : Vehicle
    {
        public String VehicleType()
        {
            return "Car";
        }
        public bool TollFreeVehicles()
        {
            return false;
        }
    }
}