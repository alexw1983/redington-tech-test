using FluentAssertions;
using NUnit.Framework;
using RedingtonTechTest.WebAPI.Models;
using RedingtonTechTest.WebAPI.Services.Validation;

namespace RedingtonTechTest.WebApi.Tests.Services.Validation
{
    [TestFixture]
    public class CalculationInputValidatorTests
    {
        [TestCase(1, 1)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(0.5, 0.5)]
        public void Should_pass_if_both_A_and_B_are_in_range(decimal a, decimal b)
        {
            // arrange
            var input = new CalculationInput
            {
                A = a,
                B = b
            };

            // act
            var actual = GetSubject().Validate(input);

            // assert
            actual.IsValid.Should().BeTrue();
            actual.Error.Should().BeNull();
        }

        [TestCase(-1)]
        [TestCase(1.1)]
        [TestCase(-0.0000001)]
        [TestCase(-999999)]
        [TestCase(9999999)]
        [TestCase(1.00000001)]
        public void Should_fail_if_input_A_is_out_of_range(decimal a)
        {
            // arrange
            var input = new CalculationInput
            {
                A = a,
                B = 0.5M
            };

            // act
            var actual = GetSubject().Validate(input);

            // assert
            actual.IsValid.Should().BeFalse();
            actual.Error.Should().Be($"Value {a} for input is out of range. Must be between 0 and 1");
        }

        [TestCase(-1)]
        [TestCase(1.1)]
        [TestCase(-0.0000001)]
        [TestCase(-999999)]
        [TestCase(9999999)]
        [TestCase(1.00000001)]
        public void Should_fail_if_input_B_is_out_of_range(decimal b)
        {
            // arrange
            var input = new CalculationInput
            {
                A = 0.5M,
                B = b
            };

            // act
            var actual = GetSubject().Validate(input);

            // assert
            actual.IsValid.Should().BeFalse();
            actual.Error.Should().Be($"Value {b} for input is out of range. Must be between 0 and 1");
        }

        private static CalculationInputValidator GetSubject()
        {
            return new CalculationInputValidator();
        }
    }
}

