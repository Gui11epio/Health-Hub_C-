using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using @enum;
using static Health_Hub.Domain.Entities.Usuario;

namespace Health_Hub.Application.DTOs.Response
{
    public class UsuarioResponse
    {
        public int Id { get; set; }
        public string EmailCorporativo { get; set; }
        public string Nome { get; set; }
        public TipoUsuario Tipo { get; set; }
        
    }
}
