using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using RedingtonTechTest.WebAPI.Controllers;
using RedingtonTechTest.WebAPI.Models;
using RedingtonTechTest.WebAPI.Services;

namespace RedingtonTechTest.WebAPI.Tests.Controllers
{
    [TestFixture]
    public class ProbabilityCalculationsControllerTests
    {
        private IProbabilityCalculationsService _service;

        [SetUp]
        public void PerTestSetup()
        {
            _service = A.Fake<IProbabilityCalculationsService>();
        }

        [Test]
        public void CombineAWithB_with_should_return_bad_request_if_service_throws_argument_out_of_range()
        {
            // arrange
            var sut = GetSubject();
            var input = new ProbabilityCalculationsRequestModel();

            A.CallTo(() => _service.CombineAWithB(input))
                .Throws<ArgumentOutOfRangeException>();

            // act
            var result = sut.CombineAWithB(input);

            // assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Test]
        public void CombineAWithB_with_should_return_ok_if_service_succeeds()
        {
            // arrange
            var sut = GetSubject();
            var input = new ProbabilityCalculationsRequestModel();
            var output = new ProbabilityCalculationsResponseModel();

            A.CallTo(() => _service.CombineAWithB(input))
                .Returns(output);

            // act
            var result = sut.CombineAWithB(input);

            // assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void EitherAOrB_with_should_return_bad_request_if_service_throws_argument_out_of_range()
        {
            // arrange
            var sut = GetSubject();
            var input = new ProbabilityCalculationsRequestModel();

            A.CallTo(() => _service.EitherAOrB(input))
                .Throws<ArgumentOutOfRangeException>();

            // act
            var result = sut.EitherAOrB(input);

            // assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Test]
        public void EitherAorB_with_should_return_ok_if_service_succeeds()
        {
            // arrange
            var sut = GetSubject();
            var input = new ProbabilityCalculationsRequestModel();
            var output = new ProbabilityCalculationsResponseModel();

            A.CallTo(() => _service.EitherAOrB(input))
                .Returns(output);

            // act
            var result = sut.EitherAOrB(input);

            // assert
            result.Should().BeOfType<OkObjectResult>();
        }

        private ProbabilityCalculationsController GetSubject()
        {
            return new ProbabilityCalculationsController(_service);
        }
    }
}