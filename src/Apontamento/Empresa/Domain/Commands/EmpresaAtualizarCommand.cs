using System;

namespace Apontamento.Empresa.Domain.Commands
{

    public partial class EmpresaAtualizarCommand : EmpresaCommand
    {
        public void SetId(Guid id)
        {
            Id = id;
        }

    }
}
