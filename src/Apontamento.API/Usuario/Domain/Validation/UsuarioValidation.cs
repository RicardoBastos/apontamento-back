using Apontamento.App.Usuario.Domain.Command;
using FluentValidation;

namespace Apontamento.App.Usuario.Validation
{
    public class UsuarioValidation : AbstractValidator<UsuarioCmd>
    {
        public void ValidarId()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("O Id precisa ser fornecido");
        }

        public void ValidarNome()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Nome não pode estar vazio")
                .MaximumLength(150).WithMessage("Nome permitido apenas 150 caracteres");
        }
    }
}
