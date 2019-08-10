using System;
using Microsoft.AspNetCore.Mvc;
using RedingtonTechTest.ProbabilityCalculator;
using RedingtonTechTest.WebAPI.Models;

namespace RedingtonTechTest.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/probability-calculations")]
    [ApiController]
    public class ProbabilityCalculationsController : ControllerBase
    {
        private readonly IProbabilityCalculator _calculator;

        public ProbabilityCalculationsController(IProbabilityCalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpPost]
        [Route("combine")]
        public IActionResult CombineAWithB([FromBody]ProbabilityCalculationsRequestModel input)
        {
            try
            {
                var result = _calculator.CombineAWithB(new Probability(input.A), new Probability(input.B));

                return Ok(result);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("either")]
        public IActionResult EitherAOrB([FromBody]ProbabilityCalculationsRequestModel input)
        {
            try
            {
                var result = _calculator.EitherAOrB(new Probability(input.A), new Probability(input.B));

                return Ok(result);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex);
            }
        }
    }
}