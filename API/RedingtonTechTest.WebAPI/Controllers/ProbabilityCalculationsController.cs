using System;
using Microsoft.AspNetCore.Mvc;
using RedingtonTechTest.WebAPI.Models;
using RedingtonTechTest.WebAPI.Services.Calculations;
using RedingtonTechTest.WebAPI.Services.Interfaces;

namespace RedingtonTechTest.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/probability-calculations")]
    [ApiController]
    public class ProbabilityCalculationsController : ControllerBase
    {
        private readonly ICalculationsService _service;
        private readonly ILoggingService _loggingService;

        public ProbabilityCalculationsController(ICalculationsService service, ILoggingService loggingService)
        {
            _service = service;
            _loggingService = loggingService;
        }

        [HttpPost]
        [Route("combine")]
        public IActionResult CombineAWithB([FromBody]CalculationsInput input)
        {
            try
            {
                var calculation = _service.CombineAWithB(input);

                _loggingService.Log(calculation);

                return Ok(calculation);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("either")]
        public IActionResult EitherAOrB([FromBody]CalculationsInput input)
        {
            try
            {
                var calculation = _service.EitherAOrB(input);

                _loggingService.Log(calculation);

                return Ok(calculation);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex);
            }
        }
    }
}