using System;

namespace TollFeeCalculator
{
    public interface IVehicle
    {
        string VehicleType { get; }
        bool IsTollFreeVehicle { get; set; }

        // String RegistrationNumber();  // Bör kanske hämta en registreringsnummer så man kan göra varje bil unik?
        // DateTime HigestExpanseWithinTheHour(); //  Kanske skall implementera detta.
    }
}