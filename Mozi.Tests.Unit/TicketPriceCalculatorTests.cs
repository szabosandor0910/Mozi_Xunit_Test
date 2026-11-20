using System;
using System.Collections.Generic;
using System.Text;

namespace Mozi.Tests.Unit
{
    public class TicketPriceCalculatorTests
    {
        [Fact]
        public void CalculatePrice_NegativeAge_ReturnsMinusOne()
        {
            // Arrange
            var calculator = new TicketPriceCalculator();

            // Act
            int result = calculator.CalculatePrice(-1, false, false);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void CalculatePrice_AgeOver120_ReturnsMinusOne()
        {
            // Arrange
            var calculator = new TicketPriceCalculator();

            // Act
            int result = calculator.CalculatePrice(121, false, false);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void CalculatePrice_FreeAgeGroupWeekend3D_ReturnsZero()
        {
            // Arrange
            var calculator = new TicketPriceCalculator();

            // Act
            int result = calculator.CalculatePrice(5, true, true);

            // Assert
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(false, false, 1990)]
        [InlineData(true, false, 2490)]
        [InlineData(false, true, 2490)]
        [InlineData(true, true, 2990)]
        public void CalculatePrice_Adult_ReturnsExpectedPrice(bool isWeekend, bool is3D, int expected)
        {
            // Arrange
            var calculator = new TicketPriceCalculator();

            // Act
            int result = calculator.CalculatePrice(30, isWeekend, is3D);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5, 0)]
        [InlineData(6, 995)]
        [InlineData(14, 995)]
        [InlineData(15, 1990)]
        [InlineData(65, 1293)]
        public void CalculatePrice_AgeBoundaries_ReturnsExpectedPrice(int age, int expected)
        {
            // Arrange
            var calculator = new TicketPriceCalculator();

            // Act
            int result = calculator.CalculatePrice(age, false, false);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 1495)]
        [InlineData(70, 1943)]
        public void CalculatePrice_DiscountWithWeekend3D_ReturnsExpectedPrice(int age, int expected)
        {
            // Arrange
            var calculator = new TicketPriceCalculator();

            // Act
            int result = calculator.CalculatePrice(age, true, true);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
