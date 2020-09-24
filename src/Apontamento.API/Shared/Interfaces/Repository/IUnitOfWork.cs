using System;

namespace Apontamento.App.Shared.Interfaces.Repository
{

    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }

}
