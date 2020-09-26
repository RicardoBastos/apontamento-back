using Apontamento.App.Usuario.Domain.Command;
using Apontamento.App.Usuario.Infrastructure.Repository;
using FluentValidation;

namespace Apontamento.App.Usuario.Validation
{
    public class SessionValidation : AbstractValidator<SessionUsuarioCmd>
    {

        public SessionValidation(IUsuarioDapperRepository usuarioDapperRepository)
        {
            ValidarUsuario(usuarioDapperRepository);
        }

        public void ValidarUsuario(IUsuarioDapperRepository usuarioDapperRepository)
        {
            RuleFor(cmdUsuario => cmdUsuario).MustAsync(async (cmdUsuario, cancellation) => {
                return await usuarioDapperRepository.SessionUsuario(cmdUsuario.Email, cmdUsuario.Senha);
            }).WithMessage("Verifique seu email e senha");
        }
    }
}
