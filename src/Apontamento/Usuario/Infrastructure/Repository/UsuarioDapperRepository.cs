using Apontamento.Usuario.Application.Query;
using Apontamento.Usuario.Infrastructure.Repository.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Threading.Tasks;

namespace Apontamento.Usuario.Infrastructure.Repository
{
    public class UsuarioDapperRepository : IUsuarioDapperRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection conn;


        public UsuarioDapperRepository(IDbConnection dbConnection, IConfiguration configuration)
        {
            _configuration = configuration;
            conn = dbConnection;
        }


        public async Task<bool> SessionUsuario(string email, string senha)
        {
            var query = @"SELECT 1 FROM USUARIO WHERE EMAIL = @EMAIL AND SENHA = @SENHA";
            var resultado = await conn.ExecuteScalarAsync<int>(query, new { EMAIL = email, SENHA = senha }) > 0 ? true :false;
            return resultado;
        }


        public async Task<UsuarioQuery> BuscarUsuarioPorEmail(string email)
        {
            var query = @"SELECT ID, NOME, EMAIL FROM USUARIO WHERE EMAIL = @EMAIL";
            var resultado = await conn.QueryFirstOrDefaultAsync<UsuarioQuery>(query, new { EMAIL = email });
            return resultado;
        }


    }
}
