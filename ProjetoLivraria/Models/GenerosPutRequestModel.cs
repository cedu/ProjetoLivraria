using System.ComponentModel.DataAnnotations;

namespace ProjetoLivraria.Models
{
    public class GenerosPutRequestModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do gênero.")]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O nome do gênero é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome do gênero deve ter pelo menos {1} caracteres.")]
        [MaxLength(255, ErrorMessage = "O nome do gênero deve ter no máximo {1} caracteres.")]
        public string? Nome { get; set; }
    }
}
