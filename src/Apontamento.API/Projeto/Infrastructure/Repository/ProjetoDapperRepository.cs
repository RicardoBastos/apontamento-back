using Apontamento.App.Projeto.Domain;
using Apontamento.App.Projeto.Application.Query;
using Apontamento.App.Projeto.Infrastructure.Repository.Interfaces;
using Apontamento.App.Shared.Controller;
using Apontamento.App.Shared.Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apontamento.App.Projeto.Repository
{
    public class ProjetoDapperRepository : IProjetoDapperRepository
    {
        private readonly IDbConnection conn;
        private StringBuilder query;

        public ProjetoDapperRepository(IDbConnection dbConnection)
        {
            conn = dbConnection;
            query = new StringBuilder();
        }

        public async Task<Response<ProjetoQuery>> BuscarProjetoPorId(Guid id)
        {
            var ProjetoQuery = await conn.QueryFirstOrDefaultAsync<ProjetoQuery>("SELECT P.ID, P.NOME, P.HORAS, P.EMPRESAID FROM PROJETO P INNER JOIN EMPRESA E ON E.ID = P.EMPRESAID WHERE P.ID = @ID", param: new { ID = id });
            return new Response<ProjetoQuery>(ProjetoQuery);
        }


        public async Task<Response<List<ProjetoListaQuery>>> BuscarProjetosPaginada(string nome, Guid empresaId, Paginacao paginacao)
        {
            dynamic param = new ExpandoObject();
            var retorno = new Response<List<ProjetoListaQuery>>();

            param.nome = nome;
            param.empresaId = empresaId;
            param.top = paginacao.Size > 0 ? paginacao.Size : 10;
            param.skip = paginacao.Page >= 0 ? paginacao.Page * paginacao.Size : 0;
            param.orderBy = string.IsNullOrEmpty(paginacao.OrderBy) ? "nome" : paginacao.OrderBy;
            param.orderDirection = string.IsNullOrEmpty(paginacao.Direction) ? "asc" : paginacao.Direction;

            string querySelect = @"SELECT
                                   P.ID,
                                   P.NOME,
                                   E.NOME EMPRESA,
                                   P.HORAS
                               FROM PROJETO P INNER JOIN EMPRESA E ON E.ID = P.EMPRESAID WHERE 1=1 ";

            
          
            if (!string.IsNullOrWhiteSpace(nome))
                query.AppendLine("AND E.[NOME] LIKE '%' + @nome + '%'");

            if (empresaId != Guid.Empty)
                query.AppendLine("AND P.[EMPRESAID] = @empresaId");


            string queryCount = $"SELECT COUNT(*) FROM PROJETO P WHERE 1 = 1 {query.ToString()}";


            query.AppendLine($"ORDER BY P.{param.orderBy} {param.orderDirection}");
            query.AppendLine(" OFFSET @skip ROWS");
            query.AppendLine(" FETCH NEXT @top ROWS ONLY");


            var sql = $"{queryCount} ; {querySelect} {query.ToString()} ";

            using (var multi = await conn.QueryMultipleAsync(sql, (object)param))
            {
                retorno.TotalRecords = multi.Read<int>().Single();
                retorno.Data = multi.Read<ProjetoListaQuery>().ToList();
            }

            return retorno;

        }

    }
}
