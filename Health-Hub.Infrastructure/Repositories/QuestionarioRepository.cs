using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Health_Hub.Domain.Entities;
using Health_Hub.Domain.Interfaces;
using Health_Hub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Health_Hub.Infrastructure.Repositories
{
    public class QuestionarioRepository : IQuestionarioRepository
    {

        private readonly AppDbContext _context;
        public QuestionarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Questionario>> GetAllAsync()
        {
            return await _context.Questionario.ToListAsync();
        }

        public async Task<(List<Questionario> Itens, int Total)> GetAllByPageAsync(int pageNumber, int pageSize)
        {
            var query = _context.Questionario.AsQueryable();
            var total = await query.CountAsync();
            var itens = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return (itens, total);
        }

        public async Task<Questionario?> GetByIdAsync(int id)
        {
            return await _context.Questionario.FindAsync(id);
        }

        public async Task<Questionario> AddAsync(Questionario questionario)
        {
            _context.Questionario.Add(questionario);
            await _context.SaveChangesAsync();
            return questionario;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var questionario = await _context.Questionario.FindAsync(id);
            if (questionario == null)
                return false;
            _context.Questionario.Remove(questionario);
            await _context.SaveChangesAsync();
            return true;
        }

        
    }

}
