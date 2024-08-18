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
            new DateTime(2024, 8, 5, 6, 0, 0),  // 8
            new DateTime(2024, 8, 5, 6, 30, 0), // 13
            new DateTime(2024, 8, 5, 7, 30, 0)  // 18
        };                                      // tot 39

            TollCalculator calculator = new TollCalculator();

            int tollFeeCar = calculator.GetTollFee(car, dates);
            Console.WriteLine($"The total toll fee for the car is: {tollFeeCar}");

            int tollFeeMotorbike = calculator.GetTollFee(motorbike, dates);
            Console.WriteLine($"The total toll fee for the motorbike is: {tollFeeMotorbike}");
        }
    }
}
