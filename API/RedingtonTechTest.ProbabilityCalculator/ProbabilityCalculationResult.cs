﻿using System;

namespace RedingtonTechTest.ProbabilityCalculator
{
    public class ProbabilityCalculationResult
    {
        public Probability Result { get; set; }

        public DateTime CalculationDate { get; set; }

        public string TypeOfCalculation { get; set; }

        public Probability[] Inputs { get; set; }
    }
}
