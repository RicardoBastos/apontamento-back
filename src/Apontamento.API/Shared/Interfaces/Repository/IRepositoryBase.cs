using System;
using System.Threading.Tasks;

namespace Apontamento.App.Shared.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        Task Salvar(TEntity obj);
        void Atualizar(TEntity obj);

    }
}
