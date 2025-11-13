using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Health_Hub.Application.DTOs.Request;
using Health_Hub.Application.DTOs.Response;
using Health_Hub.Domain.Entities;
using Health_Hub.Domain.IRepositories;
using Sprint1_C_.Application.DTOs.Response;

namespace Health_Hub.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repo;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository repo, IMapper mapper) { 
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<List<UsuarioResponse>> ObterTodos()
        {
            var usuarios = await _repo.GetAllAsync();
            return _mapper.Map<List<UsuarioResponse>>(usuarios);
        }

        public async Task<UsuarioResponse?> ObterPorId(int id)
        {
            var usuario = await _repo.GetByIdAsync(id);
            return usuario == null ? null : _mapper.Map<UsuarioResponse>(usuario);
        }

        public async Task<UsuarioResponse?> GetByEmailAsync(string email)
        {
            var usuario = await _repo.GetByEmailAsync(email);
            return usuario == null ? null : _mapper.Map<UsuarioResponse>(usuario);
        }

        public async Task<PagedResult<UsuarioResponse>> ObterPorPagina(int pageNumber, int pageSize)
        {
            var (itens, total) = await _repo.GetAllByPageAsync(pageNumber, pageSize);

            return new PagedResult<UsuarioResponse>
            {
                Numeropag = pageNumber,
                Tamnhopag = pageSize,
                Total = total,
                Itens = _mapper.Map<List<UsuarioResponse>>(itens)
            };
        }

        public async Task<UsuarioResponse> Criar(UsuarioRequest request)
        {
            var novoUsuario = _mapper.Map<Usuario>(request);
            await _repo.AddAsync(novoUsuario);
            return _mapper.Map<UsuarioResponse>(novoUsuario);
        }

        public async Task<bool> Atualizar(int id, UsuarioRequest request)
        {
            var usuario = await _repo.GetByIdAsync(id);
            if (usuario == null) return false;

            _mapper.Map(request, usuario);
            return await _repo.UpdateAsync(usuario);
        }

        public async Task<bool> Remover(int id)
        {
            return await _repo.DeleteAsync(id);
        }

    }
}

