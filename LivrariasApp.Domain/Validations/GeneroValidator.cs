using FluentValidation;
using ProjetoLivraria.Entities;

namespace ProjetoLivraria.Validations
{
    public class GeneroValidator : AbstractValidator<Genero>
    {
        public GeneroValidator() 
        {
            RuleFor(g => g.Id)
                .NotEmpty().WithMessage("O Id é obrigatório")
                   .Must(id => id != Guid.Empty).WithMessage("O Id não pode ser igual ao valor padrão.");

            RuleFor(g => g.Nome).NotEmpty().WithMessage("O nome é obrigatório")
                .Length(3, 255).WithMessage("O nome do gênero deve ter entre 3 e 255 caracteres.");
        }
    }
}
