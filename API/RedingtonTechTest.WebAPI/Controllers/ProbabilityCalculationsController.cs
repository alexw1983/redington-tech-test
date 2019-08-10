using Microsoft.AspNetCore.Mvc;
using RedingtonTechTest.WebAPI.Models;
using RedingtonTechTest.WebAPI.Services.Calculations.Interfaces;

namespace RedingtonTechTest.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/probability-calculations")]
    [ApiController]
    public class ProbabilityCalculationsController : ControllerBase
    {
        private readonly ICalculationsService _service;

        public ProbabilityCalculationsController(ICalculationsService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("combine")]
        public IActionResult CombineAWithB([FromBody]CalculationInput calculationInput)
        {
            var calculationOutput = _service.CombineAWithB(calculationInput);

            if (!calculationOutput.Validation.IsValid)
                return BadRequest(calculationOutput.Validation);

            return Ok(calculationOutput.Result);
        }

        [HttpPost]
        [Route("either")]
        public IActionResult EitherAOrB([FromBody]CalculationInput calculationInput)
        {
            var calculationOutput = _service.EitherAOrB(calculationInput);

            if (!calculationOutput.Validation.IsValid)
                return BadRequest(calculationOutput.Validation);

            return Ok(calculationOutput.Result);
        }
    }
}