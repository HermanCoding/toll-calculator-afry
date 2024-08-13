using System;

namespace TollFeeCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IVehicle car = new Car("abc123");
            IVehicle motorbike = new Motorbike("bcd123");

            DateTime[] dates = {
            new DateTime(2024, 8, 5, 6, 0, 0),
            new DateTime(2024, 8, 5, 6, 30, 0),
            new DateTime(2024, 8, 5, 7, 30, 0)
        };

            TollCalculator calculator = new TollCalculator();

            int tollFeeCar = calculator.GetTollFee(car, dates);
            Console.WriteLine($"The total toll fee for the car is: {tollFeeCar}");

            int tollFeeMotorbike = calculator.GetTollFee(motorbike, dates);
            Console.WriteLine($"The total toll fee for the motorbike is: {tollFeeMotorbike}");
        }
    }
}
