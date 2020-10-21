using Apontamento.App.Empresa.Application.Domain;
using Apontamento.App.Empresa.Application.Query;
using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;
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

namespace Apontamento.App.Empresa.Repository
{
    public class EmpresaDapperRepository : IEmpresaDapperRepository
    {
        private readonly IDbConnection conn;
        private StringBuilder query;

        public EmpresaDapperRepository(IDbConnection dbConnection)
        {
            conn = dbConnection;
            query = new StringBuilder();
        }

        public async Task<Response<EmpresaQuery>> BuscarEmpresaPorId(Guid id)
        {
            var empresaQuery = await conn.QueryFirstOrDefaultAsync<EmpresaQuery>("SELECT E.ID, E.NOME, E.STATUS FROM EMPRESA E WHERE ID = @ID", param: new { ID = id });
            return new Response<EmpresaQuery>(empresaQuery);
        }


        public async Task<Response<List<EmpresaQuery>>> BuscarEmpresasPaginada(string nome, EnumStatus status, Paginacao paginacao)
        {
            dynamic param = new ExpandoObject();
            var retorno = new Response<List<EmpresaQuery>>();

            param.nome = nome;
            param.status = status;
            param.top = paginacao.Size > 0 ? paginacao.Size : 10;
            param.skip = paginacao.Page >= 0 ? paginacao.Page * paginacao.Size : 0;
            param.orderBy = string.IsNullOrEmpty(paginacao.OrderBy) ? "nome" : paginacao.OrderBy;
            param.orderDirection = string.IsNullOrEmpty(paginacao.Direction) ? "asc" : paginacao.Direction;

            string querySelect = @"SELECT
                                   E.ID,
                                   E.NOME,
                                   E.STATUS
                               FROM EMPRESA E WHERE 1=1 ";

            
          
            if (!string.IsNullOrWhiteSpace(nome))
                query.AppendLine("AND E.[NOME] LIKE '%' + @nome + '%'");

            if (status != EnumStatus.Todos)
                query.AppendLine("AND E.[STATUS] = @status");


            string queryCount = $"SELECT COUNT(*) FROM EMPRESA E WHERE 1 = 1 {query.ToString()}";


            query.AppendLine($"ORDER BY {param.orderBy} {param.orderDirection}");
            query.AppendLine(" OFFSET @skip ROWS");
            query.AppendLine(" FETCH NEXT @top ROWS ONLY");


            var sql = $"{queryCount} ; {querySelect} {query.ToString()} ";

            using (var multi = await conn.QueryMultipleAsync(sql, (object)param))
            {
                retorno.TotalRecords = multi.Read<int>().Single();
                retorno.Data = multi.Read<EmpresaQuery>().ToList();
            }

            return retorno;

        }

    }
}
