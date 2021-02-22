using Apontamento.Shared.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Apontamento.Shared.Infra
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {

        private readonly ApontamentoContext _dataContext;

        public RepositoryBase(ApontamentoContext dataContext)
        {
            _dataContext = dataContext;
        }


        public virtual async Task<TEntity> Salvar(TEntity obj)
        {
            try
            {
                await _dataContext.Set<TEntity>().AddAsync(obj);
                //await _dataContext.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                var xx = ex.Message;
                throw;
            }
         
        }


        public virtual async Task Atualizar(TEntity obj)
        {
            await Task.FromResult(_dataContext.Entry(obj).State = EntityState.Modified);

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