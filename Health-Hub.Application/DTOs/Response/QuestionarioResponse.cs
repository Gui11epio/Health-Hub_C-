using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_Hub.Application.DTOs.Response
{
    public class QuestionarioResponse
    {        
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public int NivelEstresse { get; set; }
   
        public int QualidadeSono { get; set; }
        
        public int Ansiedade { get; set; }

        public int Sobrecarga { get; set; }
    }

}
