using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using RedingtonTechTest.WebAPI.Controllers;
using RedingtonTechTest.WebAPI.Models;
using RedingtonTechTest.WebAPI.Services.Calculations.Interfaces;
using RedingtonTechTest.WebAPI.Services.Validation;

namespace RedingtonTechTest.WebAPI.Tests.Controllers
{
    [TestFixture]
    public class ProbabilityCalculationsControllerTests
    {
        private ICalculationsService _calculationService;

        [SetUp]
        public void PerTestSetup()
        {
            _calculationService = A.Fake<ICalculationsService>();
        }

        [Test]
        public async Task CombineAWithB_should_return_bad_request_if_service_fails_validation()
        {
            // arrange
            var input = new CalculationInput();
            var failedResponse = new CalculationResult { Validation = ValidationResult.Fail("FAIL") };

            A.CallTo(() => _calculationService.CombineAWithB(input))
                .Returns(failedResponse);

            // act
            var result = await GetSubject().CombineAWithB(input);

            // assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Test]
        public async Task CombineAWithB_should_return_ok_if_service_succeeds()
        {
            // arrange
            var input = new CalculationInput();
            var goodResponse = new CalculationResult { Validation = ValidationResult.Success() };

            A.CallTo(() => _calculationService.CombineAWithB(input))
                .Returns(goodResponse);

            // act
            var result = await GetSubject().CombineAWithB(input);

            // assert
            A.CallTo(() => _calculationService.CombineAWithB(input)).MustHaveHappened();
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public async Task EitherAOrB_should_return_bad_request_if_service_fails_validation()
        {
            // arrange
            var input = new CalculationInput();
            var failedResponse = new CalculationResult { Validation = ValidationResult.Fail("FAIL") };

            A.CallTo(() => _calculationService.EitherAOrB(input))
                .Returns(failedResponse);

            // act
            var result = await GetSubject().EitherAOrB(input);

            // assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Test]
        public async Task EitherAorB_should_return_ok_if_service_succeeds()
        {
            // arrange
            var input = new CalculationInput();
            var goodResponse = new CalculationResult { Validation = ValidationResult.Success() };

            A.CallTo(() => _calculationService.EitherAOrB(input))
                .Returns(goodResponse);

            // act
            var result = await GetSubject().EitherAOrB(input);

            // assert
            result.Should().BeOfType<OkObjectResult>();
        }

        private ProbabilityCalculationsController GetSubject()
        {
            return new ProbabilityCalculationsController(_calculationService);
        }
    }
}