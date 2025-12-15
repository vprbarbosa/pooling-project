using Microsoft.AspNetCore.Mvc;
using Polling.Api.Models.Requests;
using Polling.Domain.Common;
using Pooling.Application.Interfaces;

namespace Polling.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResponsesController : ControllerBase
    {
        private readonly IResponseService _service;
        private readonly ILogger<ResponsesController> _logger;

        public ResponsesController(IResponseService service, ILogger<ResponsesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Submete uma resposta para um questionário.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Submit([FromBody] SubmitResponseRequest request)
        {
            try
            {
                await _service.Submit(request.ToDto());

                return NoContent();
            }
            catch (DomainException ex)
            {
                _logger.LogWarning(ex, ex.Message);

                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro interno ao submeter resposta");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
