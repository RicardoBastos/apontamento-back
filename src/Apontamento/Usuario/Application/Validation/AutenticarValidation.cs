using Apontamento.Usuario.Application.Command;
using Apontamento.Usuario.Infrastructure.Repository.Interfaces;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Apontamento.Usuario.Application.Validation
{

    public partial class AutenticarValidation : UsuarioValidation<AutenticarCommand>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AutenticarValidation(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;


            ValidarEmail();

            ValidarSenha();

            //Business
            ValidarAutenticar();
        }

        public void ValidarAutenticar()
        {
            RuleFor(usuario => usuario)
              .MustAsync(UsuarioExiste).WithMessage("Verifique login e senha e tente novamente");
        }


        private async Task<bool> UsuarioExiste(AutenticarCommand usuarioCmd, CancellationToken cancellationToken)
        {
            return await _usuarioRepository.GetAsync(usuario => usuario.Email == usuarioCmd.Email && usuario.Senha == usuarioCmd.Senha) != null;
        }

    }
}



