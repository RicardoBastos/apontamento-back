using Apontamento.App.Shared.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
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
            _dataContext.Set<TEntity>().Attach(obj);

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

        //public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        //{
        //    return await Context.Set<T>().Where(predicate).ToListAsync();
        //}

    }
}
