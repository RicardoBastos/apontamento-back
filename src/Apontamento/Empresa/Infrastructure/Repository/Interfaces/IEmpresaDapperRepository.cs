using Apontamento.Empresa.Domain.Domain;
using Apontamento.Empresa.Domain.Queries;
using Apontamento.Shared.Controller;
using Apontamento.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apontamento.Empresa.Infrastructure.Repository.Interfaces
{
    public interface IEmpresaDapperRepository
    {
        Task<Response<List<EmpresaQuery>>> BuscarEmpresasPaginada(string nome, EnumStatus status, Paginacao paginacao);
        Task<Response<EmpresaQuery>> BuscarEmpresaPorId(Guid id);

    }
}
