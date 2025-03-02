using System.ComponentModel.DataAnnotations;

namespace ProjetoLivraria.Models
{
    public class EditorasPutRequestModel
    {
        [Required(ErrorMessage = "Por favor, informe o id da editora.")]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O nome da editora é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome da editora deve ter pelo menos {1} caracteres.")]
        [MaxLength(255, ErrorMessage = "O nome da editora deve ter no máximo {1} caracteres.")]
        public string? Nome { get; set; }
    }
}
