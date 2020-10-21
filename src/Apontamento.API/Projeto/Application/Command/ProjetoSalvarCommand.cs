using System;

namespace Apontamento.App.Projeto.Application.Command
{

    public partial class ProjetoSalvarCommand : ProjetoCommand
    {
        public ProjetoSalvarCommand()
        {
            Id = Guid.NewGuid();
        }

    }
}
