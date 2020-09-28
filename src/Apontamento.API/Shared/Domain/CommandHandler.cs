using Apontamento.App.Shared.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apontamento.App.Shared.Domain
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;

        public CommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected void Commit()
        {
            _uow.Commit();
        }
    }
}
