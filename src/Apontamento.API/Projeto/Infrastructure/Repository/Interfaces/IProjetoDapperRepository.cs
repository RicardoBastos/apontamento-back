using Apontamento.App.Projeto.Domain;
using Apontamento.App.Projeto.Application.Query;
using Apontamento.App.Shared.Controller;
using Apontamento.App.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apontamento.App.Projeto.Infrastructure.Repository.Interfaces
{
    public interface IProjetoDapperRepository
    {
        Task<Response<List<ProjetoListaQuery>>> BuscarProjetosPaginada(string nome, Guid empresaId, Paginacao paginacao);
        Task<Response<ProjetoQuery>> BuscarProjetoPorId(Guid id);

    }
}
