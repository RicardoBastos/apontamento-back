﻿
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Apontamento.Shared.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> Salvar(TEntity obj);
        Task Atualizar(TEntity obj);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where);

    }
}
