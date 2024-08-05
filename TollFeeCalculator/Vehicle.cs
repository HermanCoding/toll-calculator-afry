using System;

namespace TollFeeCalculator
{
    public interface Vehicle
    {
        String VehicleType();
        Boolean TollFreeVehicles();
        // String RegistrationNumber();  // Bör kanske hämta en registreringsnummer så man kan göra varje bil unik?
        // DateTime HigestExpanseWithinTheHoue(); //  Kanske skall implementera detta.
    }
}