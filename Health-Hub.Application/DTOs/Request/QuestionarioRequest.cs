using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_Hub.Application.DTOs.Request
{
    public class QuestionarioRequest
    {
        [Required(ErrorMessage = "O Id do usário é obrigatório")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O nível de estresse é obrigatório")]
        public int NivelEstresse { get; set; }

        [Required(ErrorMessage = "O nível da qualidade do sono é obrigatória")]
        public int QualidadeSono { get; set; }

        [Required(ErrorMessage = "O nível de ansiedade é obrigatório")]
        public int Ansiedade { get; set; }

        [Required(ErrorMessage = "O nível de sobrecarga é obrigatório")]
        public int Sobrecarga { get; set; }
    }

}
