using Apontamento.App.Empresa.Application.Command;
using Apontamento.App.Shared.Domain;
using System;
using System.Collections.Generic;

namespace Apontamento.App.Empresa.Domain
{
    public class Empresa : Base
    {
        public Empresa()
        {

        }

        public string Nome { get; private set; }
        public bool Status { get; private set; }
        public List<Projeto.Domain.Projeto> Projetos { get; private set; }
        public void SetEmpresa(EmpresaCommand empresa)
        {
            this.Id = empresa.Id;
            this.Nome = empresa.Nome;
            this.Status = empresa.Status;
        }

    }
}

