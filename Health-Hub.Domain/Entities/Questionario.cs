using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_Hub.Domain.Entities
{
    public class Questionario
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataPreenchimento { get; set; } = DateTime.UtcNow;
        public int NivelEstresse { get; set; }
        public int QualidadeSono { get; set; }
        public int Ansiedade { get; set; }
        public int Sobrecarga { get; set; }
    }

}
