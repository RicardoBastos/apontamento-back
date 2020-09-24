using Apontamento.App.Empresa.Domain.Query;
using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;
using Apontamento.App.Shared.Controller;
using Dapper;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Apontamento.App.Empresa.Repository
{
    public class EmpresaDapperRepository : IEmpresaDapperRepository
    {
        private readonly IDbConnection conn;

        public EmpresaDapperRepository(IDbConnection dbConnection)
        {
            conn = dbConnection;
        }

        public async Task<EmpresaQuery> BuscarEmpresaPorId(Guid id)
        {
            return await conn.QueryFirstOrDefaultAsync<EmpresaQuery>("SELECT E.ID, E.NOME, E.STATUS FROM EMPRESA E WHERE ID = @ID", param: new { ID = id });
        }

        public async Task<RetornoGrid<EmpresaQuery>> BuscarEmpresasPaginada()
        {
            var retorno = new RetornoGrid<EmpresaQuery>();

            var query = @"SELECT COUNT(*) FROM EMPRESA;

                        SELECT
                            P.ID,
                            P.NOME,
                            P.STATUS
                        FROM EMPRESA P WHERE 1=1";


            using (var multi = await conn.QueryMultipleAsync(query))
            {
                retorno.TotalRecords = multi.Read<int>().Single();
                retorno.Data = multi.Read<EmpresaQuery>().ToList();
            }

            return retorno;

        }

      
    }
}
