using StringCalculator;
using System;
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

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("1,2,3,4", 10)]
        [InlineData("1,2,3,4,5", 15)]
        public void ShouldReturnAdditionOnMultipleEntries(string input, int expectedResult)
        {
            var adder = new Adder();
            var calculation = adder.Add(input);
            Assert.Equal(expectedResult, calculation);
        }

        [Theory]
        [InlineData("1\n2,3", 6)]
        [InlineData("1\n2,3\n4",10)]
        [InlineData("1\n2",3)]
        public void ShouldReturnAdditionOnEndOfLine(string input, int expectedResult)
        {
            var adder = new Adder();
            var calculation = adder.Add(input);
            Assert.Equal(expectedResult, calculation);
        }

        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//\n\n1\n2", 3)]
        [InlineData("//,\n1,2", 3)]
        public void ShouldReturnAdditionOnCustomDelimiter(string input, int expectedResult)
        {
            var adder = new Adder();
            var calculation = adder.Add(input);
            Assert.Equal(expectedResult, calculation);
        }

        [Theory]
        [InlineData("-1,2", "-1")]
        [InlineData("1,-2", "-2")]
        [InlineData("1,2,-3", "-3")]
        [InlineData("-", "-")]
        [InlineData("-1,-2", "-1, -2")]
        [InlineData("//;\n-1;-2", "-1, -2")]
        public void ShouldThrowExceptionOnNegativeNumbers(string input, string negativeString)
        {
            var adder = new Adder();
            var expectedException = Assert.Throws<ArgumentException>(() => adder.Add(input));
            Assert.Equal(Constants.NoNegativeNumbers + negativeString, expectedException.Message);
        }
    }
}