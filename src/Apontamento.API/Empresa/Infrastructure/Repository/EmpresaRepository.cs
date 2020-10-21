using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;
using Apontamento.App.Shared.Infra;

namespace Apontamento.App.Empresa.Repository
{
    public class EmpresaRepository : RepositoryBase<Domain.Empresa>, IEmpresaRepository
    {
        private readonly ApontamentoContext _context;
        public EmpresaRepository(ApontamentoContext context):base(context)
        {
            _context = context;
        }

        public ApontamentoContext Context { get; }

    }
}
