using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using @enum;

namespace Health_Hub.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string EmailCorporativo { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public TipoUsuario Tipo { get; set; }

        
    }
}
