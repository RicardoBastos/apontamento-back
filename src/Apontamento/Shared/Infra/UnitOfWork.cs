
using Apontamento.Shared.Interfaces.Repository;

namespace Apontamento.Shared.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApontamentoContext _context;
        public UnitOfWork(ApontamentoContext context)
        {
            _context = context;
        }

        public virtual void Commit()
        {
            _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}