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


        private static ProbabilityCalculator GetSubject()
        {
            return new ProbabilityCalculator();
        }
    }
}