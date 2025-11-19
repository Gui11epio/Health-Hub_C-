using AutoMapper;
using Health_Hub.Application.DTOs.Request;
using Health_Hub.Application.DTOs.Response;
using Health_Hub.Application.Services;
using Health_Hub.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sprint1_C_.Application.DTOs.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace Health_Hub.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiversion}/UsuarioV2")]
    [SwaggerTag("Controlador para gerenciar usuários - Versão 2")]
    public class UsuarioControllerV2 : ControllerBase
    {
        private readonly UsuarioService _svc;
        

        public UsuarioControllerV2(UsuarioService svc)
        {
            _svc = svc;
            
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(
            Summary = "Obtém um usuário por ID",
            Description = "Retorna os detalhes de um usuário específico."
        )]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _svc.ObterPorId(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UsuarioResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [SwaggerOperation(
            Summary = "Obtém todos os usuários",
            Description = "Retorna uma lista de todos os usuários cadastrados."
        )]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _svc.ObterTodos();
            if (usuarios == null || !usuarios.Any()) return NoContent();
            return Ok(usuarios);
        }

        
        [HttpPost]
        [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(
            Summary = "Cria um novo usuário",
            Description = "Adiciona um novo usuário ao sistema."
        )]
        public async Task<IActionResult> Create([FromBody] UsuarioRequest dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _svc.Criar(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(
            Summary = "Atualiza um usuário existente",
            Description = "Atualiza os detalhes de um usuário específico."
        )]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioRequest dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _svc.Atualizar(id, dto);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(
            Summary = "Remove um usuário",
            Description = "Remove um usuário específico do sistema."
        )]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _svc.Remover(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
