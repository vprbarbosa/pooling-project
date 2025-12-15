using Microsoft.AspNetCore.Mvc;
using Polling.Api.Mappers;
using Polling.Api.Models.Requests;
using Polling.Domain.Common;
using Pooling.Application.Interfaces;

namespace Polling.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionnairesController : ControllerBase
    {
        private readonly IQuestionnaireService _service;
        private readonly ILogger<QuestionnairesController> _logger;

        public QuestionnairesController(IQuestionnaireService service, ILogger<QuestionnairesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Cria um novo questionário.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateQuestionnaireRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var createDto = request.ToDto();
                var createdDto = await _service.Create(createDto);
                var response = createdDto.ToResponse();

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = response.Id },
                    response
                );
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var dto = await _service.GetById(id);

                if (dto == null)
                    return NotFound();

                var response = dto.ToResponse();

                return Ok(response);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar questionário");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
