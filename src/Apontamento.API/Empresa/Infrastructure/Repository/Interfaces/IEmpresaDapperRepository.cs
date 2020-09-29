using Apontamento.App.Empresa.Application.Domain;
using Apontamento.App.Empresa.Application.Domain.Query;
using Apontamento.App.Shared.Controller;
using Apontamento.App.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apontamento.App.Empresa.Infrastructure.Repository.Interfaces
{
    public interface IEmpresaDapperRepository
    {
        Task<Response<List<EmpresaQuery>>> BuscarEmpresasPaginada(string nome, EnumStatus status, Paginacao paginacao);
        Task<Response<EmpresaQuery>> BuscarEmpresaPorId(Guid id);

    }
}
