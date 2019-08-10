using System;
using FluentAssertions;
using NUnit.Framework;

// ReSharper disable ObjectCreationAsStatement

namespace RedingtonTechTest.ProbabilityLibrary.Tests
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
            error.Message.Should().Contain($"{value} is not between 0 and 1");
        }

        [TestCase(0.5, 0.5, 0.25)]
        [TestCase(0, 1, 0)]
        [TestCase(1, 1, 1)]
        [TestCase(0, 0, 0)]
        [TestCase(0.25, 0.25, 0.0625)]
        [TestCase(0.3, 0.9, 0.27)]
        [TestCase(0.3, 0.3, 0.09)]
        public void And_should_return_the_product_of_the_inputs(decimal a, decimal b, decimal expected)
        {
            // arrange
            var A = new Probability(a);
            var B = new Probability(b);

            // act
            var actual = A.And(B);

            // assert
            actual.Should().BeEquivalentTo(new Probability(expected));
        }

        [TestCase(0.5, 0.5, 0.75)]
        [TestCase(0, 1, 1)]
        [TestCase(1, 1, 1)]
        [TestCase(0, 0, 0)]
        [TestCase(0.25, 0.25, 0.4375)]
        [TestCase(0.3, 0.9, 0.93)]
        [TestCase(0.3, 0.3, 0.51)]
        public void Or_should_return_the_sum_of_the_inputs_minus_their_product(decimal a, decimal b, decimal expected)
        {
            // arrange
            var A = new Probability(a);
            var B = new Probability(b);

            // act
            var actual = A.Or(B);

            // assert
            actual.Should().BeEquivalentTo(new Probability(expected));
        }
    }
}
