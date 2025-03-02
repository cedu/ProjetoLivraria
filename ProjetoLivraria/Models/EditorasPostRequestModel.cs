using System.ComponentModel.DataAnnotations;

namespace ProjetoLivraria.Models
{
    public class EditorasPostRequestModel
    {
        [Required(ErrorMessage = "O nome da editora é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome da editora deve ter pelo menos {1} caracteres.")]
        [MaxLength(255, ErrorMessage = "O nome da editora deve ter no máximo {1} caracteres.")]
        public string? Nome { get; set; }
    }
}
