using Health_Hub.Application.DTOs.Response;
using Health_Hub.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Sprint1_C_.Application.DTOs.Response;

namespace Health_Hub.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/questionarios")]
    public class QuestionarioControllerV2 : ControllerBase
    {
        private readonly QuestionarioService _svc;
        public QuestionarioControllerV2(QuestionarioService svc)
        {
            _svc = svc;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var questionario = await _svc.ObterPorId(id);
            if(questionario == null) return NotFound();
            return Ok(questionario);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var questionario = await _svc.ObterTodos();
            if(questionario == null) return NotFound();
            return Ok(questionario);
        }

        [HttpGet("pagina")]
        public async Task<ActionResult<PagedResult<QuestionarioResponse>>> GetPaged(int numeroPag = 1, int tamanhoPag = 10)
        {
            var result = await _svc.ObterPorPagina(numeroPag, tamanhoPag);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] QuestionarioResponse request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                

            var createdQuestionario = await _svc.Criar(request);
            return CreatedAtAction(nameof(GetById), new { id = createdQuestionario.Id }, createdQuestionario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _svc.Deletar(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
