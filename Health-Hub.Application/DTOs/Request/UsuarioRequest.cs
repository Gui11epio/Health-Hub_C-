using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using @enum;
using static Health_Hub.Domain.Entities.Usuario;

namespace Health_Hub.Application.DTOs.Request
{
    public class UsuarioRequest
    {
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido")]
        [StringLength(150, ErrorMessage = "O e-mail deve ter no máximo 150 caracteres")]
        public string EmailCorporativo { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "O nome do usuário deve ter entre 3 e 100 caracteres")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ\s'-]+$",
            ErrorMessage = "O nome do usuário contém caracteres inválidos")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(50, MinimumLength = 8,
        ErrorMessage = "A senha deve ter no mínimo 8 e no máximo 50 caracteres")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$",
        ErrorMessage = "A senha deve conter pelo menos uma letra maiúscula, uma minúscula, um número e um caractere especial (@$!%*?&)")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O tipo de usuário é obrigatório")]
        public TipoUsuario Tipo { get; set; }
    }
}
