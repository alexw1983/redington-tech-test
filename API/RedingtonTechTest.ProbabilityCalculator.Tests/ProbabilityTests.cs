using System;
using FluentAssertions;
using NUnit.Framework;
// ReSharper disable ObjectCreationAsStatement

namespace RedingtonTechTest.ProbabilityCalculator.Tests
{
    [TestFixture]
    public class ProbabilityTests
    {
        [TestCase(-1)]
        [TestCase(1.1)]
        [TestCase(-0.0000001)]
        [TestCase(-999999)]
        [TestCase(9999999)]
        [TestCase(1.00000001)]
        public void Probability_initialization_should_throw_if_value_is_out_of_Range(decimal value)
        {
            // arrange + act
            var error = Assert.Throws<ArgumentOutOfRangeException>(() => new Probability(value));

            // assert
            error.Message.Should().Contain("Parameter name: value");
            error.Message.Should().Contain("Probability must be between 0 and 1");
        }
    }
}
