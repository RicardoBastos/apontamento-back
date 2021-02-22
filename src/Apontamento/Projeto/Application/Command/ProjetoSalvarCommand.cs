using System;

namespace Apontamento.Projeto.Application.Command
{

    public partial class ProjetoSalvarCommand : ProjetoCommand
    {
        public ProjetoSalvarCommand()
        {
            Id = Guid.NewGuid();
        }

    }
}
