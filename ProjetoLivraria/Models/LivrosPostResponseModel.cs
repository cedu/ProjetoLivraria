namespace ProjetoLivraria.Models
{
    public class LivrosPostResponseModel
    {
        public Guid? Id { get; set; }
        public string? Titulo { get; set; }
        public string? ISBN { get; set; }
        public string? Autor { get; set; }
        public string? Sinopse { get; set; }
        public string? CaminhoImagem { get; set; }

        public Guid? UsuarioId { get; set; }
        public string? NomeUsuario { get; set; }

        public Guid? GeneroId { get; set; }
        public string? NomeGenero { get; set; }

        public Guid? EditoraId { get; set; }
        public string? NomeEditora { get; set; }
    }
}
