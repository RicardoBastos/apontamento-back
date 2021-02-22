using Apontamento.Empresa.Infrastructure.Repository.Interfaces;
using Apontamento.Shared.Infra;

namespace Apontamento.Empresa.Repository
{
    public class EmpresaRepository : RepositoryBase<Domain.Entities.Empresa>, IEmpresaRepository
    {
        private readonly ApontamentoContext _context;
        public EmpresaRepository(ApontamentoContext context):base(context)
        {
            _context = context;
        }

        public ApontamentoContext Context { get; }

    }
}
