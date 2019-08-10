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
        public void CombineWith_should_return_the_product_of_the_inputs(decimal a, decimal b, decimal expected)
        {
            // arrange
            var A = new Probability(a);
            var B = new Probability(b);
            var sut = GetSubject();

            // act
            var actual = sut.CombineAWithB(A, B);

            // assert
            actual.Result.Should().BeEquivalentTo(new Probability(expected));
        }

        [Test]
        public void CombineWith_should_populate_result_object_correctly()
        {
            // arrange
            var A = new Probability(0.5M);
            var B = new Probability(0.5M);
            var sut = GetSubject();

            // act
            var actual = sut.CombineAWithB(A, B);

            // assert
            actual.CalculationDate.Date.Should().Be(DateTime.UtcNow.Date);
            actual.Inputs.Should().BeEquivalentTo(A, B);
            actual.TypeOfCalculation.Should().Be("Combine A With B");
        }

        [TestCase(0.5, 0.5, 0.75)]
        [TestCase(0, 1, 1)]
        [TestCase(1, 1, 1)]
        [TestCase(0, 0, 0)]
        [TestCase(0.25, 0.25, 0.4375)]
        [TestCase(0.3, 0.9, 0.93)]
        [TestCase(0.3, 0.3, 0.51)]
        public void Either_should_return_the_sum_of_the_inputs_minus_their_product(decimal a, decimal b, decimal expected)
        {
            // arrange
            var A = new Probability(a);
            var B = new Probability(b);
            var sut = GetSubject();

            // act
            var actual = sut.EitherAOrB(A, B);

            // assert
            actual.Result.Should().BeEquivalentTo(new Probability(expected));
        }

        [Test]
        public void Either_should_populate_result_object_correctly()
        {
            // arrange
            var A = new Probability(0.5M);
            var B = new Probability(0.5M);
            var sut = GetSubject();

            // act
            var actual = sut.EitherAOrB(A, B);

            // assert
            actual.CalculationDate.Date.Should().Be(DateTime.UtcNow.Date);
            actual.Inputs.Should().BeEquivalentTo(A, B);
            actual.TypeOfCalculation.Should().Be("Either A Or B");
        }

        private static ProbabilityCalculator GetSubject()
        {
            return new ProbabilityCalculator();
        }
    }
}