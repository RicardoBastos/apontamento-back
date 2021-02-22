using Apontamento.Projeto.Infrastructure.Repository.Interfaces;
using Apontamento.Shared.Infra;

namespace Apontamento.Projeto.Repository
{
    public class ProjetoRepository : RepositoryBase<Domain.Projeto>, IProjetoRepository
    {
        private readonly ApontamentoContext _context;
        public ProjetoRepository(ApontamentoContext context):base(context)
        {
            _context = context;
        }

        public ApontamentoContext Context { get; }

    }
}
