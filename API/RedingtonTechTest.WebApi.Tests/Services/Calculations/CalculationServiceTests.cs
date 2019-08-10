using System;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using RedingtonTechTest.ProbabilityLibrary;
using RedingtonTechTest.WebAPI.Models;
using RedingtonTechTest.WebAPI.Services.Calculations;
using RedingtonTechTest.WebAPI.Services.Logging.Interfaces;
using RedingtonTechTest.WebAPI.Services.Validation;
using RedingtonTechTest.WebAPI.Services.Validation.Interfaces;

namespace RedingtonTechTest.WebApi.Tests.Services.Calculations
{
    [TestFixture]
    public class CalculationServiceTests
    {
        private ILoggingService _loggingService;
        private IValidator<CalculationInput> _validator;

        [SetUp]
        public void PerTestSetUp()
        {
            _loggingService = A.Fake<ILoggingService>();
            _validator = A.Fake<IValidator<CalculationInput>>();

            A.CallTo(() => _validator.Validate(A<CalculationInput>._))
                .Returns(ValidationResult.Success());
        }

        [Test]
        public void CombineWith_should_return_the_probability_of_A_and_B()
        {
            // arrange
            const decimal A = 0.5M;
            const decimal B = 0.5M;
            var sut = GetSubject();

            // act
            var actual = sut.CombineAWithB(new CalculationInput { A = A, B = B });

            // assert
            var a = new Probability(A);
            var b = new Probability(B);
            var expected = a.And(b).Value;
            actual.Result.Should().Be(expected);
        }

        [Test]
        public void CombineWith_should_populate_result_object_correctly()
        {
            // arrange
            const decimal A = 0.5M;
            const decimal B = 0.5M;

            // act
            var actual = GetSubject().CombineAWithB(new CalculationInput { A = A, B = B });

            // assert
            actual.Validation.Should().BeEquivalentTo(ValidationResult.Success());
            actual.CalculationDate.Date.Should().Be(DateTime.UtcNow.Date);
            actual.Inputs.Should().BeEquivalentTo(new Probability(A), new Probability(B));
            actual.TypeOfCalculation.Should().Be("A combined with B");
        }

        [Test]
        public void CombineWith_should_return_if_validation_fails()
        {
            // arrange
            const decimal inputA = 0.5M;
            const decimal inputB = 0.5M;

            A.CallTo(() => _validator.Validate(A<CalculationInput>._))
                .Returns(ValidationResult.Fail("FAIL"));

            // act
            var actual = GetSubject().CombineAWithB(new CalculationInput { A = inputA, B = inputB });

            // assert
            actual.Validation.Should().BeEquivalentTo(ValidationResult.Fail("FAIL"));
        }

        [Test]
        public void Either_should_return_the_probability_of_A_or_B()
        {
            // arrange
            const decimal A = 0.5M;
            const decimal B = 0.5M;

            // act
            var actual = GetSubject().EitherAOrB(new CalculationInput { A = A, B = B });

            // assert
            var a = new Probability(A);
            var b = new Probability(B);
            var expected = a.Or(b).Value;
            actual.Result.Should().Be(expected);
        }

        [Test]
        public void Either_should_populate_result_object_correctly()
        {
            // arrange
            const decimal A = 0.5M;
            const decimal B = 0.5M;

            // act
            var actual = GetSubject().EitherAOrB(new CalculationInput { A = A, B = B });

            // assert
            actual.Validation.Should().BeEquivalentTo(ValidationResult.Success());
            actual.CalculationDate.Date.Should().Be(DateTime.UtcNow.Date);
            actual.Inputs.Should().BeEquivalentTo(new Probability(A), new Probability(B));
            actual.TypeOfCalculation.Should().Be("Either A or B");
        }

        [Test]
        public void Either_should_return_if_validation_fails()
        {
            // arrange
            const decimal inputA = 0.5M;
            const decimal inputB = 0.5M;

            A.CallTo(() => _validator.Validate(A<CalculationInput>._))
                .Returns(ValidationResult.Fail("FAIL"));

            // act
            var actual = GetSubject().EitherAOrB(new CalculationInput { A = inputA, B = inputB });

            // assert
            actual.Validation.Should().BeEquivalentTo(ValidationResult.Fail("FAIL"));
        }

        private CalculationService GetSubject()
        {
            return new CalculationService(_loggingService, _validator);
        }
    }
}