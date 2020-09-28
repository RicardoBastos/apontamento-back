using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apontamento.App.Empresa.Domain.Command
{

    public partial class EmpresaSalvarCommand : EmpresaCommand
    {
        public EmpresaSalvarCommand()
        {
            Id = Guid.NewGuid();
        }

    }
}
