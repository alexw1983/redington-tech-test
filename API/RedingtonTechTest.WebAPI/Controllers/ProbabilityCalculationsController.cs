using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedingtonTechTest.WebAPI.Models;
using RedingtonTechTest.WebAPI.Services.Calculations.Interfaces;
using RedingtonTechTest.WebAPI.Services.Validation;

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
        [ProducesResponseType(typeof(decimal), 200)]
        [ProducesResponseType(typeof(ValidationResult), 400)]
        public async Task<IActionResult> CombineAWithB([FromBody]CalculationInput input)
        {
            var output = await _service.CombineAWithB(input);

            if (!output.Validation.IsValid)
                return BadRequest(output.Validation);

            return Ok(output.Result);
        }

        [HttpPost]
        [Route("either")]
        [ProducesResponseType(typeof(decimal), 200)]
        [ProducesResponseType(typeof(ValidationResult), 400)]
        public async Task<IActionResult> EitherAOrB([FromBody]CalculationInput input)
        {
            var output = await _service.EitherAOrB(input);

            if (!output.Validation.IsValid)
                return BadRequest(output.Validation);

            return Ok(output.Result);
        }
    }
}