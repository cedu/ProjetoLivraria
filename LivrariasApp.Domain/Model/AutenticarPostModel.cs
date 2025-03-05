using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariasApp.Domain.Model
{
    public class AutenticarPostModel
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email de acesso.")]
        public string? Email { get; set; }

        [MinLength(8, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a senha de acesso.")]
        public string? Senha { get; set; }
    }
}
