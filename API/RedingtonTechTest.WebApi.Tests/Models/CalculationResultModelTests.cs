using System;
using FluentAssertions;
using NUnit.Framework;
using RedingtonTechTest.ProbabilityLibrary;
using RedingtonTechTest.WebAPI.Models;
using RedingtonTechTest.WebAPI.Services.Validation;

namespace RedingtonTechTest.WebApi.Tests.Models
{
    [TestFixture]
    public class CalculationResultModelTests
    {
        [Test]
        public void ToString_should_return_validation_failed_message()
        {
            // arrange
            var model = new CalculationResult
            {
                Validation = ValidationResult.Fail("FAIL"),
                Result = 0.5M,
                Inputs = new[] { new Probability(1M), new Probability(0.5M) },
                CalculationDate = new DateTime(2019, 1, 2, 3, 4, 5),
                TypeOfCalculation = "TEST"
            };

            // act
            var actual = model.ToString();

            // assert
            actual.Should().Be("2019-01-02T03:04:05 => Validation Failed => FAIL");
        }

        [Test]
        public void ToString_should_return_success_message()
        {
            // arrange
            var model = new CalculationResult
            {
                Validation = ValidationResult.Success(),
                Result = 0.5M,
                Inputs = new[] { new Probability(1M), new Probability(0.5M) },
                CalculationDate = new DateTime(2019, 1, 2, 3, 4, 5),
                TypeOfCalculation = "TEST"
            };

            // act
            var actual = model.ToString();

            // assert
            actual.Should().Be("2019-01-02T03:04:05 => Success => Type of Calculation: 'TEST', Inputs: [1,0.5], Result: 0.5");
        }
    }
}
