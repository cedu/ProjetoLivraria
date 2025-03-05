using System.ComponentModel.DataAnnotations;

namespace ProjetoLivraria.Models
{
    public class UsuariosPostResponseModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool IsAdmin { get; set; }
    }
}
