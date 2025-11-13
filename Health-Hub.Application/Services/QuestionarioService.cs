using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Health_Hub.Application.DTOs.Response;
using Health_Hub.Domain.Entities;
using Health_Hub.Domain.Interfaces;
using Sprint1_C_.Application.DTOs.Response;

namespace Health_Hub.Application.Services
{
    public class QuestionarioService
    {
        private readonly IQuestionarioRepository _repo;
        private readonly IMapper _mapper;

        public QuestionarioService(IQuestionarioRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<QuestionarioResponse>> ObterTodos()
        {
            var questionarios = await _repo.GetAllAsync();
            return _mapper.Map<List<QuestionarioResponse>>(questionarios);
        }

        public async Task<QuestionarioResponse?> ObterPorId(int id)
        {
            var questionario = await _repo.GetByIdAsync(id);
            return questionario == null ? null : _mapper.Map<QuestionarioResponse>(questionario);
        }

        public async Task<PagedResult<QuestionarioResponse>> ObterPorPagina(int pageNumber, int pageSize)
        {
            var (itens, total) = await _repo.GetAllByPageAsync(pageNumber, pageSize);
            return new PagedResult<QuestionarioResponse>
            {
                Numeropag = pageNumber,
                Tamnhopag = pageSize,
                Total = total,
                Itens = _mapper.Map<List<QuestionarioResponse>>(itens)
            };
        }

        public async Task<QuestionarioResponse> Criar(QuestionarioResponse request)
        {
            var novoQuestionario = _mapper.Map<Questionario>(request);
            await _repo.AddAsync(novoQuestionario);
            return _mapper.Map<QuestionarioResponse>(novoQuestionario);
        }

        public async Task<bool> Deletar(int id)
        {
            return await _repo.DeleteAsync(id);
        }

    }

}
