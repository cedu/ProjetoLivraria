using System.ComponentModel.DataAnnotations;

namespace ProjetoLivraria.Models
{
    public class UsuariosPostRequestModel
    {
        [MinLength(8, ErrorMessage ="Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage ="Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage="Por favor, informe o nome do usuário")]
        public string? Nome { get; set; }

        [Required(ErrorMessage ="Por favor, informe o email do usuário")]
        [EmailAddress(ErrorMessage ="Informe um email válido")]
        public string? Email { get; set; }

        [Required(ErrorMessage ="Por favor, informe uma senha do usuário")]
        [MinLength(10, ErrorMessage ="A senha deve ter no mínimo {1} caracteres.")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento do usuário.")]
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        public bool IsAdmin { get; set; }
    }
}
