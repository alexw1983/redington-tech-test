using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using RedingtonTechTest.WebAPI.Controllers;
using RedingtonTechTest.WebAPI.Models;
using RedingtonTechTest.WebAPI.Services.Calculations;
using RedingtonTechTest.WebAPI.Services.Interfaces;

namespace RedingtonTechTest.WebAPI.Tests.Controllers
{
    [TestFixture]
    public class ProbabilityCalculationsControllerTests
    {
        private ICalculationsService _calculationService;
        private ILoggingService _loggingService;

        [SetUp]
        public void PerTestSetup()
        {
            _calculationService = A.Fake<ICalculationsService>();
            _loggingService = A.Fake<ILoggingService>();
        }

        [Test]
        public void CombineAWithB_should_return_bad_request_if_service_throws_argument_out_of_range()
        {
            // arrange
            var sut = GetSubject();
            var input = new CalculationsInput();

            A.CallTo(() => _calculationService.CombineAWithB(input))
                .Throws<ArgumentOutOfRangeException>();

            // act
            var result = sut.CombineAWithB(input);

            // assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Test]
        public void CombineAWithB_should_return_ok_if_service_succeeds()
        {
            // arrange
            var sut = GetSubject();
            var input = new CalculationsInput();
            var output = new CalculationResult();

            A.CallTo(() => _calculationService.CombineAWithB(input))
                .Returns(output);

            // act
            var result = sut.CombineAWithB(input);

            // assert
            A.CallTo(() => _calculationService.CombineAWithB(input)).MustHaveHappened();
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void CombineAWithB_should_log_result()
        {
            // arrange
            var sut = GetSubject();
            var input = new CalculationsInput();
            var output = new CalculationResult();

            A.CallTo(() => _calculationService.CombineAWithB(input))
                .Returns(output);

            // act
            var result = sut.CombineAWithB(input);

            // assert
            A.CallTo(() => _loggingService.Log(output)).MustHaveHappened();
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void EitherAOrB_should_return_bad_request_if_service_throws_argument_out_of_range()
        {
            // arrange
            var sut = GetSubject();
            var input = new CalculationsInput();

            A.CallTo(() => _calculationService.EitherAOrB(input))
                .Throws<ArgumentOutOfRangeException>();

            // act
            var result = sut.EitherAOrB(input);

            // assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Test]
        public void EitherAorB_should_return_ok_if_service_succeeds()
        {
            // arrange
            var sut = GetSubject();
            var input = new CalculationsInput();
            var output = new CalculationResult();

            A.CallTo(() => _calculationService.EitherAOrB(input))
                .Returns(output);

            // act
            var result = sut.EitherAOrB(input);

            // assert
            A.CallTo(() => _loggingService.Log(output)).MustHaveHappened();
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void EitherAorB_should_log_result()
        {
            // arrange
            var sut = GetSubject();
            var input = new CalculationsInput();
            var output = new CalculationResult();

            A.CallTo(() => _calculationService.CombineAWithB(input))
                .Returns(output);

            // act
            var result = sut.CombineAWithB(input);

            // assert
            A.CallTo(() => _loggingService.Log(output)).MustHaveHappened();
            result.Should().BeOfType<OkObjectResult>();
        }

        private ProbabilityCalculationsController GetSubject()
        {
            return new ProbabilityCalculationsController(_calculationService, _loggingService);
        }
    }
}