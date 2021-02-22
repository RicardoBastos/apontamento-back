using Apontamento.Shared.Infra;
using Apontamento.Usuario.Infrastructure.Repository.Interfaces;

namespace Apontamento.Usuario.Infrastructure.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario.Domain.Usuario>, IUsuarioRepository
    {
        private readonly ApontamentoContext _context;
        public UsuarioRepository(ApontamentoContext context) : base(context)
        {
            _context = context;
        }

        public ApontamentoContext Context { get; }

    }
}
