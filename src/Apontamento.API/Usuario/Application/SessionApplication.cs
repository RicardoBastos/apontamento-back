using Apontamento.App.Shared.Domain;
using Apontamento.App.Usuario.Application.Interface;
using Apontamento.App.Usuario.Domain.Command;
using Apontamento.App.Usuario.Domain.Query;
using FluentValidation.Results;
using MediatR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Apontamento.App.Empresa.Application
{
    public class SessionApplication: ISessionApplication
    {
        private readonly IMediator _mediator;

        public SessionApplication(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<Result> Autenticar(SessionUsuarioCmd sessionUsuarioCmd)
        {
            var retornoAutenticar = await _mediator.Send<ValidationResult>(sessionUsuarioCmd);

            if (retornoAutenticar.Errors.Count > 0) {
                return new Result() {Errors = retornoAutenticar.Errors.Select(err => err.ErrorMessage).ToList() }; 
            }

            var retornoUsuarioComToken = await _mediator.Send<UsuarioQuery>(new SessionUsuarioTokenCmd() { Email = sessionUsuarioCmd.Email });

            return new Result() { Retorno = retornoUsuarioComToken };
        }

  
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
