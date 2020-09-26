using Apontamento.App.Usuario.Domain.Query;
using System.Threading.Tasks;

namespace Apontamento.App.Usuario.Infrastructure.Repository
{
    public interface IUsuarioDapperRepository
    {
        Task<bool> SessionUsuario(string email, string senha);
        Task<UsuarioQuery> BuscarUsuarioPorEmail(string email);

    }
}
