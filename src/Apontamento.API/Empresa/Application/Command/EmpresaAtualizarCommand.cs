﻿using System;

namespace Apontamento.App.Empresa.Application.Command
{

    public partial class EmpresaAtualizarCommand : EmpresaCommand
    {
        public void SetId(Guid id)
        {
            Id = id;
        }

    }
}