using Apontamento.App.Shared.Domain;
using Apontamento.App.Usuario.Domain.Command;
using System;
using System.Threading.Tasks;

namespace Apontamento.App.Usuario.Application.Interface
{
    public interface ISessionApplication : IDisposable
    {
        Task<Result> Autenticar(SessionUsuarioCmd sessionUsuarioCmd);

    }
}
