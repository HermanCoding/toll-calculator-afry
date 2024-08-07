using TollFeeCalculator;

namespace TollFeeCalculatorTest
{
    public class TollCalculatorTest
    {
        public TollCalculatorTest()
        {
        }

        [Fact]
        public void GetTollFeeTest_ShouldReturn24()
        {
            // Arange
            TollCalculator tollCalc = new TollCalculator();
            IVehicle car = new Car();
            DateTime[] dates = {
                new DateTime(2023, 8, 4, 6, 0, 0),
                new DateTime(2023, 8, 4, 13, 30, 0),
                new DateTime(2023, 8, 4, 18, 00, 0)
            };

            int expectedTotalFee = 24;
            int actualTotalFee = 0;

            // Act
            foreach (var date in dates)
            {
                actualTotalFee += tollCalc.GetTollFee(date, car);
            }

            // Assert
            Assert.Equal(expectedTotalFee, actualTotalFee);
        }

        [Fact]
        public void IsTollFreeDateTest_ShouldReturnTrue()
        {
            DateTime date = new DateTime(2023,08,13);

        }
    }
}