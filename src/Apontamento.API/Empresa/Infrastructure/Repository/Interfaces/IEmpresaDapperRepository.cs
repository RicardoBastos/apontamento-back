using Apontamento.App.Empresa.Domain.Query;
using Apontamento.App.Shared.Controller;
using System;
using System.Threading.Tasks;

namespace Apontamento.App.Empresa.Infrastructure.Repository.Interfaces
{
    public interface IEmpresaDapperRepository
    {
        Task<RetornoGrid<EmpresaQuery>> BuscarEmpresasPaginada();

        Task<EmpresaQuery> BuscarEmpresaPorId(Guid id);
    }
}
