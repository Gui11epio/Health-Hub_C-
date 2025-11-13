using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Health_Hub.Domain.Entities;
using Health_Hub.Domain.IRepositories;
using Health_Hub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Health_Hub.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        } 
            
        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<(List<Usuario> Itens, int Total)> GetAllByPageAsync(int pageNumber, int pageSize)
        {
            var query = _context.Usuario.AsQueryable();
            var total = await query.CountAsync();
            var itens = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return (itens, total);
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _context.Usuario.FirstOrDefaultAsync(u => u.EmailCorporativo == email);
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuario.FindAsync(id);
        }


        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;

        }

        public async Task<bool> UpdateAsync(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
                return false;
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
