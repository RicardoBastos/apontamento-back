using Apontamento.App.Projeto.Infrastructure.Repository.Interfaces;
using Apontamento.App.Shared.Infra;

namespace Apontamento.App.Projeto.Repository
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
