using System;
using FluentAssertions;
using NUnit.Framework;
using RedingtonTechTest.WebAPI.Models;
using RedingtonTechTest.WebAPI.Services.Calculations;

namespace RedingtonTechTest.WebApi.Tests.Services.Calculations
{
    [TestFixture]
    public class CalculationServiceTests
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
            var sut = GetSubject();

            // act
            var actual = sut.CombineAWithB(new CalculationsInput { A = a, B = b });

            // assert
            actual.Result.Should().BeEquivalentTo(new Probability(expected));
        }

        [Test]
        public void CombineWith_should_populate_result_object_correctly()
        {
            // arrange
            var A = 0.5M;
            var B = 0.5M;
            var sut = GetSubject();

            // act
            var actual = sut.CombineAWithB(new CalculationsInput { A = A, B = B });

            // assert
            actual.CalculationDate.Date.Should().Be(DateTime.UtcNow.Date);
            actual.Inputs.Should().BeEquivalentTo(new Probability(A), new Probability(B));
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
            var sut = GetSubject();

            // act
            var actual = sut.EitherAOrB(new CalculationsInput { A = a, B = b });

            // assert
            actual.Result.Should().BeEquivalentTo(new Probability(expected));
        }

        [Test]
        public void Either_should_populate_result_object_correctly()
        {
            // arrange
            const decimal A = 0.5M;
            const decimal B = 0.5M;
            var sut = GetSubject();

            // act
            var actual = sut.EitherAOrB(new CalculationsInput { A = A, B = B });

            // assert
            actual.CalculationDate.Date.Should().Be(DateTime.UtcNow.Date);
            actual.Inputs.Should().BeEquivalentTo(new Probability(A), new Probability(B));
            actual.TypeOfCalculation.Should().Be("Either A Or B");
        }

        private static CalculationService GetSubject()
        {
            return new CalculationService();
        }
    }
}