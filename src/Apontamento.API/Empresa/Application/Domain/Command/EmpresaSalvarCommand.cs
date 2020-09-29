using System;

namespace Apontamento.App.Empresa.Application.Domain.Command
{

    public partial class EmpresaSalvarCommand : EmpresaCommand
    {
        public EmpresaSalvarCommand()
        {
            Id = Guid.NewGuid();
        }

    }
}
