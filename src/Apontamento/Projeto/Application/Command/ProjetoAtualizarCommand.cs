using System;

namespace Apontamento.Projeto.Application.Command
{

    public partial class ProjetoAtualizarCommand : ProjetoCommand
    {
        public void SetId(Guid id)
        {
            Id = id;
        }

    }
}
