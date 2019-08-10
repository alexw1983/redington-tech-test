using System;
using Microsoft.AspNetCore.Mvc;
using RedingtonTechTest.WebAPI.Models;
using RedingtonTechTest.WebAPI.Services;

namespace RedingtonTechTest.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/probability-calculations")]
    [ApiController]
    public class ProbabilityCalculationsController : ControllerBase
    {
        private readonly IProbabilityCalculationsService _service;

        public ProbabilityCalculationsController(IProbabilityCalculationsService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("combine")]
        public IActionResult CombineAWithB([FromBody]ProbabilityCalculationsRequestModel input)
        {
            try
            {
                var result = _service.CombineAWithB(input);

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
                var result = _service.EitherAOrB(input);

                return Ok(result);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex);
            }
        }
    }
}