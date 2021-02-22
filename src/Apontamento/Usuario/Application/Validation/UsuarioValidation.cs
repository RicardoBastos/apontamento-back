using Apontamento.Usuario.Application.Command;
using FluentValidation;

namespace Apontamento.Usuario.Application.Validation
{
    public class UsuarioValidation<T> : AbstractValidator<T> where T : UsuarioCommand
    {

        public void ValidarEmail()
        {
            RuleFor(usuario => usuario.Email)
                 .NotNull().WithMessage("E-mail é obrigatório")
                 .EmailAddress().WithMessage("Favor digitar um e-mail válido");

        }

        public void ValidarSenha()
        {
            RuleFor(usuario => usuario.Senha)
                .NotEmpty().WithMessage("Senha é obrigatória")
                .MaximumLength(100).WithMessage("Senha permitido até 20 caracteres");
        }

    }
}



