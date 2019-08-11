using System;
using System.Linq;
using RedingtonTechTest.ProbabilityLibrary;
using RedingtonTechTest.WebAPI.Services.Validation;

namespace RedingtonTechTest.WebAPI.Models
{
    public class CalculationResult
    {
        public ValidationResult Validation { get; set; }

        public decimal Result { get; set; }

        public DateTime CalculationDate { get; set; }

        public string TypeOfCalculation { get; set; }

        public Probability[] Inputs { get; set; }

        public CalculationResult()
        {
            Inputs = new Probability[0];
        }

        public override string ToString()
        {
            if (!Validation.IsValid)
                return $"{CalculationDate:s} => Validation Failed => {Validation.Error}";

            return
                $"{CalculationDate:s} => Success => Type of Calculation: '{TypeOfCalculation}', Inputs: [{string.Join(',', Inputs.Select(x => x.Value))}], Result: {Result}";
        }
    }
}
