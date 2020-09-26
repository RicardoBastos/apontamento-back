using Apontamento.App.Empresa.Domain;
using Apontamento.App.Empresa.Domain.Query;
using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;
using Apontamento.App.Shared.Controller;
using Dapper;
using System;
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

        public async Task<EmpresaQuery> BuscarEmpresaPorId(Guid id)
        {
            return await conn.QueryFirstOrDefaultAsync<EmpresaQuery>("SELECT E.ID, E.NOME, E.STATUS FROM EMPRESA E WHERE ID = @ID", param: new { ID = id });
        }

        public async Task<EmpresaQuery> BuscarEmpresaPorNome(string nome, Guid id)
        {
            return await conn.QueryFirstOrDefaultAsync<EmpresaQuery>(
                "SELECT E.ID, E.NOME, E.STATUS FROM EMPRESA E WHERE E.NOME = @NOME AND E.ID <> @ID", param: new { NOME = nome, ID = id });
        }

        public async Task<RetornoGrid<EmpresaQuery>> BuscarEmpresasPaginada(string nome, EnumStatus status, Paginacao paginacao)
        {
            dynamic param = new ExpandoObject();
            var retorno = new RetornoGrid<EmpresaQuery>();

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
