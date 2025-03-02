using FluentValidation;
using ProjetoLivraria.Entities;

namespace ProjetoLivraria.Validations
{
    public class EditoraValidator : AbstractValidator<Editora>
    {
        public EditoraValidator() 
        {
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage("O Id é obrigatório")
                   .Must(id => id != Guid.Empty).WithMessage("O Id não pode ser igual ao valor padrão.");

            RuleFor(e => e.Nome).NotEmpty().WithMessage("O nome é obrigatório")
                .Length(3, 255).WithMessage("O nome da editora deve ter entre 3 e 255 caracteres.");
        }
    }
}
