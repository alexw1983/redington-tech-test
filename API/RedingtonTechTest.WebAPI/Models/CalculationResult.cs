﻿using System;
using RedingtonTechTest.ProbabilityLibrary;

namespace RedingtonTechTest.WebAPI.Models
{
    public class CalculationResult
    {
        public Probability Result { get; set; }

        public DateTime CalculationDate { get; set; }

        public string TypeOfCalculation { get; set; }

        public Probability[] Inputs { get; set; }
    }
}