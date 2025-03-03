namespace ProjetoLivraria.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool IsAdmin { get; set; }

        public DateTime? CadastradoEm { get; set; }
        public DateTime? UltimaAtualizacaoEm { get; set; }

        public List<Livro>? Livros { get; set; }

    }
}
