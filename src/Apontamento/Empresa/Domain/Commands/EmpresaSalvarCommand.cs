using System;

namespace Apontamento.Empresa.Domain.Commands
{
    public partial class EmpresaSalvarCommand : EmpresaCommand
    {
        public EmpresaSalvarCommand()
        {
            Id = Guid.NewGuid();
        }

    }
}
