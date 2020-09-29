using Apontamento.App.Shared.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Apontamento.App.Shared.Infra
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {

        private readonly DbContext _dataContext;

        public RepositoryBase(DbContext dataContext)
        {
            _dataContext = dataContext;
        }


        public virtual async Task Salvar(TEntity obj)
        {
            await _dataContext.Set<TEntity>().AddAsync(obj);
        }


        public virtual void Atualizar(TEntity obj)
        {
            _dataContext.Entry(obj).State = EntityState.Modified;
        }

        private bool _disposed = false;

        ~RepositoryBase() =>
            Dispose();

        public void Dispose()
        {
            if (!_disposed)
            {
                _dataContext.Dispose();
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dataContext.Set<TEntity>().FirstOrDefaultAsync(where);
        }

    }
}
