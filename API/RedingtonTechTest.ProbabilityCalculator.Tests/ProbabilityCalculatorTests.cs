using System;
using FluentAssertions;
using NUnit.Framework;

namespace RedingtonTechTest.ProbabilityCalculator.Tests
{
    [TestFixture]
    public class ProbabilityCalculatorTests
    {
        [TestCase(0.5, 0.5, 0.25)]
        [TestCase(0, 1, 0)]
        [TestCase(1, 1, 1)]
        [TestCase(0, 0, 0)]
        [TestCase(0.25, 0.25, 0.0625)]
        [TestCase(0.3, 0.9, 0.27)]
        [TestCase(0.3, 0.3, 0.09)]
        public void CombineWith_should_return_the_product_of_the_inputs(decimal A, decimal B, decimal expected)
        {
            // arrange
            var sut = GetSubject();

            // act
            var actual = sut.CombineWith(A, B);

            // assert
            actual.Should().Be(expected);
        }

        [TestCase(-1, 1.1)]
        [TestCase(-99999, 99999)]
        [TestCase(-0.000001, 1.000000001)]
        [TestCase(1.1, -1)]
        [TestCase(99999, -99999)]
        [TestCase(1.000001, -0.000000001)]
        public void CombineWith_should_throw_if_either_input_is_less_than_0_or_greater_than_1(decimal A, decimal B)
        {
            // arrange
            var sut = GetSubject();

            // act
            var error = Assert.Throws<ArgumentOutOfRangeException>(() => sut.CombineWith(A, B));

            // assert
            error.Message.Should().Contain("Probability values must be between 0 and 1");
        }

        [TestCase(0.5, 0.5, 0.75)]
        [TestCase(0, 1, 1)]
        [TestCase(1, 1, 1)]
        [TestCase(0, 0, 0)]
        [TestCase(0.25, 0.25, 0.4375)]
        [TestCase(0.3, 0.9, 0.93)]
        [TestCase(0.3, 0.3, 0.51)]
        public void Either_should_return_the_sum_of_the_inputs_minus_their_product(decimal A, decimal B, decimal expected)
        {
            // arrange
            var sut = GetSubject();

            // act
            var actual = sut.Either(A, B);

            // assert
            actual.Should().Be(expected);
        }


        [TestCase(-1, 1.1)]
        [TestCase(-99999, 99999)]
        [TestCase(-0.000001, 1.000000001)]
        [TestCase(1.1, -1)]
        [TestCase(99999, -99999)]
        [TestCase(1.000001, -0.000000001)]
        public void Either_should_throw_if_either_input_is_less_than_0_or_greater_than_1(decimal A, decimal B)
        {
            // arrange
            var sut = GetSubject();

            // act
            var error = Assert.Throws<ArgumentOutOfRangeException>(() => sut.CombineWith(A, B));

            // assert
            error.Message.Should().Contain("Probability values must be between 0 and 1");
        }

        private static ProbabilityCalculator GetSubject()
        {
            return new ProbabilityCalculator();
        }
    }
}