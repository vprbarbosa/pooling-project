using Microsoft.AspNetCore.Mvc;
using Pooling.Application.Interfaces;
using Polling.Api.Mappers;

namespace Polling.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultsController : ControllerBase
    {
        private readonly IResultService _service;
        
        public ResultsController(IResultService service, ILogger<ResultsController> logger)
        {
            _service = service;
        }

        /// <summary>
        /// Obtém o resultado sumarizado de um questionário.
        /// </summary>
        [HttpGet("{questionnaireId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid questionnaireId)
        {
            var results = await _service.GetResults(questionnaireId);

            var response = results
                .Select(r => r.ToResponse())
                .ToList();

            return Ok(response);
        }
    }
}
