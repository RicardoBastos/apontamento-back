using Apontamento.Usuario.Application.Query;
using System.Threading.Tasks;

namespace Apontamento.Usuario.Infrastructure.Repository.Interfaces
{
    public interface IUsuarioDapperRepository
    {
        Task<bool> SessionUsuario(string email, string senha);
        Task<UsuarioQuery> BuscarUsuarioPorEmail(string email);

    }
}
