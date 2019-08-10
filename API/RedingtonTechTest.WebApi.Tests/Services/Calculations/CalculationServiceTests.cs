using System;
using FluentAssertions;
using NUnit.Framework;
using RedingtonTechTest.ProbabilityLibrary;
using RedingtonTechTest.WebAPI.Models;
using RedingtonTechTest.WebAPI.Services.Calculations;

namespace RedingtonTechTest.WebApi.Tests.Services.Calculations
{
    [TestFixture]
    public class CalculationServiceTests
    {
        [Test]
        public void CombineWith_should_return_the_probability_of_A_and_B()
        {
            // arrange
            const decimal A = 0.5M;
            const decimal B = 0.5M;
            var sut = GetSubject();

            // act
            var actual = sut.CombineAWithB(new CalculationsInput { A = A, B = B });

            // assert
            var a = new Probability(A);
            var b = new Probability(B);
            actual.Result.Should().BeEquivalentTo(a.And(b));
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
            actual.TypeOfCalculation.Should().Be("A combined with B");
        }

        [Test]
        public void Either_should_return_the_probability_of_A_or_B()
        {
            // arrange
            const decimal A = 0.5M;
            const decimal B = 0.5M;
            var sut = GetSubject();

            // act
            var actual = sut.EitherAOrB(new CalculationsInput { A = A, B = B });

            // assert
            var a = new Probability(A);
            var b = new Probability(B);
            actual.Result.Should().BeEquivalentTo(a.Or(b));
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
            actual.TypeOfCalculation.Should().Be("Either A or B");
        }

        private static CalculationService GetSubject()
        {
            return new CalculationService();
        }
    }
}