using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Health_Hub.Domain.Entities;

namespace Health_Hub.Domain.Interfaces
{
    public interface IQuestionarioRepository
    {
        Task<List<Questionario>> GetAllAsync();
        Task<Questionario?> GetByIdAsync(int id);
        Task<(List<Questionario> Itens, int Total)> GetAllByPageAsync(int pageNumber, int pageSize);
        Task<Questionario> AddAsync(Questionario questionario);
        Task<bool> DeleteAsync(int id);

    }

}
