namespace ProjetoLivraria.Entities
{
    public class Livro
    {
        public Guid Id { get; set; }
        public string? Titulo { get; set; }
        public string? ISBN { get; set; }
        public string? Autor { get; set; }
        public string? Sinopse { get; set; }
        public string? CaminhoImagem { get; set; }

        public DateTime? CadastradoEm { get; set; }
        public DateTime? UltimaAtualizacaoEm { get; set; }

        //Relacionamento: Um livro pertence a um usuário
        public Guid UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        // Relacionamento: Um livro pertence a um gênero
        public Guid GeneroId { get; set; }
        public Genero? Genero { get; set; }

        // Relacionamento: Um livro pertence a uma editora
        public Guid EditoraId { get; set; }
        public Editora? Editora { get; set; }
    }
}
