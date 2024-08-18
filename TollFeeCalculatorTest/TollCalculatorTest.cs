using TollFeeCalculator;

namespace TollFeeCalculatorTest
{
    public class TollCalculatorTest
    {
        private readonly TollCalculator _tollCalc;
        private readonly IVehicle _car;
        public TollCalculatorTest()
        {
            _tollCalc = new TollCalculator();
            _car = new Car();
        }

        [Fact]
        public void GetTollFeeTest_ShouldReturn24()
        {
            // Arange
            DateTime[] dates = {
                new DateTime(2024, 8, 7, 6, 0, 0),
                new DateTime(2024, 8, 7, 13, 30, 0),
                new DateTime(2024, 8, 7, 18, 00, 0)
            };

            int expectedTotalFee = 24;

            // Act
            int actualTotalFee = _tollCalc.GetTollFee(_car, dates);

            // Assert
            Assert.Equal(expectedTotalFee, actualTotalFee);
        }

        [Fact]
        public void GetTollFeeTest_ShouldReturn13_HighestFeeWithinTheHour()
        {
            // Arange
            DateTime[] dates = {
                new DateTime(2024, 8, 7, 6, 25, 0),
                new DateTime(2024, 8, 7, 6, 30, 0)
            };

            int expectedTotalFee = 13;

            // Act
            int actualTotalFee = _tollCalc.GetTollFee(_car, dates);

            // Assert
            Assert.Equal(expectedTotalFee, actualTotalFee);
        }

        [Fact]
        public void GetTollFeeTest_ShouldReturnZero_TestTollFreeDates()
        {
            // Arange
            DateTime[] dates = {
                new DateTime(2024, 1, 1),
                new DateTime(2024, 1, 6),
                new DateTime(2024, 3, 29),
                new DateTime(2024, 3, 31),
                new DateTime(2024,4,1),
                new DateTime(2024,5,1),
                new DateTime(2024,5,9),
                new DateTime(2024,5,19)
            };
            // Act
            int actualTotalFee = _tollCalc.GetTollFee(_car, dates);
            // Assert
            Assert.Equal(0, actualTotalFee);
        }

        [Fact]
        public void GetTollFeeTest_ShouldReturn60_MultiplePassesExceedingMaxTollFee()
        {
            // Arrange
            DateTime[] dates = {
        new DateTime(2024, 8, 7, 6, 25, 0),
        new DateTime(2024, 8, 7, 7, 30, 0),
        new DateTime(2024, 8, 7, 8, 15, 0),
        new DateTime(2024, 8, 7, 15, 15, 0),
        new DateTime(2024, 8, 7, 17, 0, 0)
    };

            int expectedTotalFee = 60;

            // Act
            int actualTotalFee = _tollCalc.GetTollFee(_car, dates);

            // Assert
            Assert.Equal(expectedTotalFee, actualTotalFee);
        }
    }
}