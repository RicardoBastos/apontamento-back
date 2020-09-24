using Apontamento.App.Empresa.Domain.Command;
using Apontamento.App.Shared.Domain;
using System;
using System.Threading.Tasks;

namespace Apontamento.App.Empresa.Application.Interface
{
    public interface IEmpresaApplication : IDisposable
    {
        Task<Result> SalvarEmpresa(EmpresaSalvarCmd empresaSalvarCmd);
        Task<Result> AtualizarEmpresa(EmpresaAtualizarCmd empresaAtualizarCmd);

    }
}
