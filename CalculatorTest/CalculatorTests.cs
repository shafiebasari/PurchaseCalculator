using Domain;
using System.Diagnostics;
using Web_API.Model;
using FluentAssertions;
using FakeItEasy;

namespace CalculatorTest
{
    public class CalculatorTests
    {
        [Fact]
        public void Calculator_CalculatorVAT_ReturnModel()
        {
            var calculator = new Calculator();
            VATCalculatorModel expected = new()
            {
                Price = Math.Round(7.00, 2),
                VAT = Math.Round(0.91, 2),
                Pnv = Math.Round(7.91, 2)
            };

            var result = calculator.VATCalculator(7, 0, 0, 13);

            result.Should().BeEquivalentTo(expected);
            result.Should().NotBeNull();
            result.Should().BeOfType<VATCalculatorModel>();
        }

    }
}