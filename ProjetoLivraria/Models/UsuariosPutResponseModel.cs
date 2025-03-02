namespace ProjetoLivraria.Models
{
    public class UsuariosPutResponseModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime? DataHoraUltimaAtualizacao { get; set; }
    }
}