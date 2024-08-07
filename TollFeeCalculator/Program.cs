using System;

namespace TollFeeCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IVehicle car = new Car();
            IVehicle motorbike = new Motorbike();

            DateTime[] dates = {
            new DateTime(2023, 8, 4, 6, 0, 0),
            new DateTime(2023, 8, 4, 6, 30, 0),
            new DateTime(2023, 8, 4, 7, 30, 0)
        };

            TollCalculator calculator = new TollCalculator();

            int tollFeeCar = calculator.GetTollFee(car, dates);
            Console.WriteLine($"The total toll fee for the car is: {tollFeeCar}");

            int tollFeeMotorbike = calculator.GetTollFee(motorbike, dates);
            Console.WriteLine($"The total toll fee for the motorbike is: {tollFeeMotorbike}");
        }
    }
}
