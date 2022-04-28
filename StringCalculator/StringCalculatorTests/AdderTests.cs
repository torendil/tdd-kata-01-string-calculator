using StringCalculator;
using Xunit;

namespace StringCalculatorTests
{
    public class AdderTest
    {
        [Fact]
        public void ShouldReturn0OnEmptyString()
        {
            var adder = new Adder();
            var calculation = adder.Add(string.Empty);
            Assert.Equal(0, calculation);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("24", 24)]
        public void ShouldReturnInputOnSingleDigit(string input, int expectedResult)
        {
            var adder = new Adder();
            var calculation = adder.Add(input);
            Assert.Equal(expectedResult, calculation);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("10,2", 12)]
        [InlineData("10,20", 30)]
        public void ShouldReturnAdditionOnTwoEntries(string input, int expectedResult)
        {
            var adder = new Adder();
            var calculation = adder.Add(input);
            Assert.Equal(expectedResult, calculation);
        }
    }
}