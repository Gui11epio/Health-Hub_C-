using Health_Hub.Application.DTOs.Request;
using Health_Hub.Application.DTOs.Response;
using Health_Hub.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Sprint1_C_.Application.DTOs.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace Health_Hub.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiversion}/QuestionarioV2")]
    [SwaggerTag("Controlador para gerenciar questionários - Versão 2")]
    public class QuestionarioControllerV2 : ControllerBase
    {
        private readonly QuestionarioService _svc;
        public QuestionarioControllerV2(QuestionarioService svc)
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
        

        [HttpPost]
        [ProducesResponseType(typeof(QuestionarioResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(
            Summary = "Cria um novo questionário e gera uma análise de saúde mental.",
            Description = "Com base nos níveis de estresse, sono, ansiedade e sobrecarga informados, retorna um resumo sobre o bem-estar mental do colaborador."
        )]
        public async Task<IActionResult> Create([FromBody] QuestionarioRequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                

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
