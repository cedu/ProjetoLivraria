using FluentValidation;
using ProjetoLivraria.Entities;

namespace ProjetoLivraria.Validations
{
    public class LivroValidator : AbstractValidator<Livro>
    {
        public LivroValidator() 
        {
            RuleFor(l => l.Id)
                .NotEmpty().WithMessage("O Id é obrigatório")
                   .Must(id => id != Guid.Empty).WithMessage("O Id não pode ser igual ao valor padrão.");

            RuleFor(l => l.Titulo).NotEmpty().WithMessage("O titulo do livro é obrigatório")
                .Length(3, 255).WithMessage("O título do livro deve ter entre 3 e 255 caracteres.");

            RuleFor(l => l.ISBN).NotEmpty().WithMessage("O ISBN do livro é obrigatório")
                .Length(10, 20).WithMessage("O ISBN do livro deve ter entre 10 e 20 caracteres.");

            RuleFor(l => l.Autor).NotEmpty().WithMessage("O Autor do livro é obrigatório")
                .Length(3, 255).WithMessage("O Autor do livro deve ter entre 3 e 255 caracteres.");

            RuleFor(l => l.Sinopse).MaximumLength(5000).WithMessage("A Sinopse do livro não pode ultrapassar 5000 caracteres.");

            RuleFor(l => l.CaminhoImagem).MaximumLength(500).WithMessage("O caminho da imagem do livro não pode ultrapassar 500 caracteres.");

            RuleFor(l => l.UsuarioId).NotEmpty().WithMessage("O Id do usuário é obrigatório.");

            RuleFor(l => l.GeneroId).NotEmpty().WithMessage("O Id do gênero é obrigatório.");

            RuleFor(l => l.EditoraId).NotEmpty().WithMessage("O Id da editora é obrigatório.");
        }
    }
}
