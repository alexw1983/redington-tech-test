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
        public IActionResult CombineAWithB([FromBody]CalculationInput input)
        {
            var output = _service.CombineAWithB(input);

            if (!output.Validation.IsValid)
                return BadRequest(output.Validation);

            return Ok(output.Result);
        }

        [HttpPost]
        [Route("either")]
        public IActionResult EitherAOrB([FromBody]CalculationInput input)
        {
            var output = _service.EitherAOrB(input);

            if (!output.Validation.IsValid)
                return BadRequest(output.Validation);

            return Ok(output.Result);
        }
    }
}