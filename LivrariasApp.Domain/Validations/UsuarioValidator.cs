using FluentValidation;
using ProjetoLivraria.Entities;

namespace ProjetoLivraria.Validations
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator() 
        {
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("O Id é obrigatório")
                   .Must(id => id != Guid.Empty).WithMessage("O Id não pode ser igual ao valor padrão.");

            RuleFor(u => u.Nome).NotEmpty().WithMessage("O nome é obrigatório")
                .Length(8, 150).WithMessage("O nome do usuário deve ter entre 8 e 150 caracteres.");

            RuleFor(u => u.Email).NotEmpty().WithMessage("O email do usuário é obrigatório.")
            .EmailAddress().WithMessage("Informe um email válido.");

            RuleFor(u => u.Senha).NotEmpty().WithMessage("A senha do usuário é obrigatória.")
            .MinimumLength(10).WithMessage("A senha deve ter no mínimo 10 caracteres.");

            RuleFor(u => u.DataNascimento)
            .NotEmpty().WithMessage("A data de nascimento do usuário é obrigatória.");
        }
    }
}
