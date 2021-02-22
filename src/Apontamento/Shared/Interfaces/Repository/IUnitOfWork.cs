using System;

namespace Apontamento.Shared.Interfaces.Repository
{

    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }

}