using System;

namespace RedingtonTechTest.WebAPI.Services.Calculations
{
    public class Probability
    {
        private static bool IsValid(decimal probability) => probability >= 0 && probability <= 1;

        public decimal Value { get; }

        public Probability(decimal value)
        {
            Value = value;
            if(!IsValid(value))
                throw new ArgumentOutOfRangeException(nameof(value), "Probability must be between 0 and 1");
        }
    }
}
