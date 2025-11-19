using Health_Hub.Application.DTOs.Request;
using Health_Hub.Application.DTOs.Response;
using Health_Hub.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Sprint1_C_.Application.DTOs.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace Health_Hub.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiversion}/QuestionarioV1")]
    [SwaggerTag("Controlador para gerenciar questionários")]
    public class QuestionarioController : ControllerBase
    {
        private readonly QuestionarioService _svc;
        public QuestionarioController(QuestionarioService svc)
        {
            _svc = svc;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(QuestionarioResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(
            Summary = "Obtém um questionário por ID",
            Description = "Retorna os detalhes de um questionário específico"
        )]
        public async Task<IActionResult> GetById(int id)
        {
            var questionario = await _svc.ObterPorId(id);
            if(questionario == null) return NotFound();
            return Ok(questionario);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<QuestionarioResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [SwaggerOperation(
            Summary = "Obtém todos os questionários",
            Description = "Retorna uma lista de todos os questionários cadastrados."
        )]
        public async Task<IActionResult> GetAll()
        {
            var questionario = await _svc.ObterTodos();
            if(questionario == null) return NotFound();
            return Ok(questionario);
        }

        [HttpGet("pagina")]
        [ProducesResponseType(typeof(PagedResult<QuestionarioResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [SwaggerOperation(
            Summary = "Obtém questionários paginados",
            Description = "Retorna uma lista paginada de questionários."
        )]
        public async Task<ActionResult<PagedResult<QuestionarioResponse>>> GetPaged(int numeroPag = 1, int tamanhoPag = 10)
        {
            var result = await _svc.ObterPorPagina(numeroPag, tamanhoPag);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(QuestionarioResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(
            Summary = "Cria um novo questionário e gera uma análise de saúde mental.",
            Description = "Com base nos níveis de estresse, sono, ansiedade e sobrecarga informados, retorna um resumo sobre o bem-estar mental do colaborador."
        )]
        [ProducesResponseType(typeof(QuestionarioResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] QuestionarioRequest request)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdQuestionario = await _svc.Criar(request);
            return CreatedAtAction(nameof(GetById), new { id = createdQuestionario.Id }, createdQuestionario);

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(
            Summary = "Remove um questionário",
            Description = "Remove um questionário específico do sistema."
        )]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _svc.Deletar(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
