using System;
using Xunit;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        //Calculator calculator = new();
        [Fact]
        public void ShouldSumm()
        {
            var actual = Calculator.DoOperation(2, 2, "a");
            Assert.Equal(4, actual);
        }
        [Fact]
        public void ShouldSubstract()
        {
            var actual = Calculator.DoOperation(2, 2, "s");
            Assert.Equal(0, actual);
        }
        [Fact]
        public void ShouldMultiply()
        {
            var actual = Calculator.DoOperation(2, 2, "m");
            Assert.Equal(4, actual);
        }
        [Fact]
        public void ShouldDivide()
        {
            var actual = Calculator.DoOperation(2, 2, "d");
            Assert.Equal(1, actual);
        }
        [Fact]
        public void ShouldDoNothing()
        {
            var actual = Calculator.DoOperation(2, 2, "o");
            Assert.Equal(double.NaN, actual);
        }
        [Fact]
        public void Should()
        {
            var actual = Calculator.DoOperation(2, 2, "o");
            Assert.Equal(double.NaN, actual);
        }

    }
}
