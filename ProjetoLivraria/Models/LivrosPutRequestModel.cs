using System.ComponentModel.DataAnnotations;

namespace ProjetoLivraria.Models
{
    public class LivrosPutRequestModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do livro.")]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O título do livro é obrigatório.")]
        [MinLength(2, ErrorMessage = "O título deve ter pelo menos {1} caracteres.")]
        [MaxLength(255, ErrorMessage = "O título deve ter no máximo {1} caracteres.")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "O ISBN é obrigatório.")]
        [RegularExpression(@"^\d{10}(\d{3})?$", ErrorMessage = "O ISBN deve ter 10 ou 13 dígitos numéricos.")]
        public string? ISBN { get; set; }

        [Required(ErrorMessage = "O nome do autor é obrigatório.")]
        [MinLength(2, ErrorMessage = "O nome do autor deve ter pelo menos {1} caracteres.")]
        [MaxLength(255, ErrorMessage = "O nome do autor deve ter no máximo {1} caracteres.")]
        public string? Autor { get; set; }

        [Required(ErrorMessage = "A sinopse é obrigatória.")]
        [MaxLength(5000, ErrorMessage = "A sinopse deve ter no máximo {1} caracteres.")]
        public string? Sinopse { get; set; }

        public string? CaminhoImagem { get; set; } // Pode ser opcional

        [Required(ErrorMessage = "O usuário dono do livro é obrigatório.")]
        public Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "O gênero do livro é obrigatório.")]
        public Guid GeneroId { get; set; }

        [Required(ErrorMessage = "A editora do livro é obrigatória.")]
        public Guid EditoraId { get; set; }
    }
}
