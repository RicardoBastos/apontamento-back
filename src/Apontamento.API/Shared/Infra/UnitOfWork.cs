using Apontamento.App.Shared.Interfaces.Repository;

namespace Apontamento.App.Shared.Infra
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
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
