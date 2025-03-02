namespace ProjetoLivraria.Entities
{
    public class Editora
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }

        public DateTime? CadastradoEm { get; set; }
        public DateTime? UltimaAtualizacaoEm { get; set; }
    }
}
