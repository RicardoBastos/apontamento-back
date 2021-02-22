using Apontamento.Projeto.Application.Query;
using Apontamento.Shared.Controller;
using Apontamento.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apontamento.Projeto.Infrastructure.Repository.Interfaces
{
    public interface IProjetoDapperRepository
    {
        Task<Response<List<ProjetoListaQuery>>> BuscarProjetosPaginada(string nome, Guid empresaId, Paginacao paginacao);
        Task<Response<ProjetoQuery>> BuscarProjetoPorId(Guid id);

    }
}
