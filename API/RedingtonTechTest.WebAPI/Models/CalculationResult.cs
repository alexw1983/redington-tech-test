using System;
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
    }
}
