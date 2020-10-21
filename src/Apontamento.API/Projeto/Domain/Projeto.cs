using Apontamento.App.Empresa.Application.Command;
using Apontamento.App.Projeto.Application.Command;
using Apontamento.App.Shared.Domain;
using System;

namespace Apontamento.App.Projeto.Domain
{
    public class Projeto : Base
    {
        public Projeto()
        {

        }

        public string Nome { get; private set; }
        public int Horas { get; private set; }
        public Guid EmpresaId { get; private set; }
        public Empresa.Domain.Empresa Empresa { get; private set; }

        public void SetProjeto(ProjetoCommand projeto)
        {
            this.Id = projeto.Id;
            this.Nome = projeto.Nome;
            this.Horas = projeto.Horas;
            this.EmpresaId = projeto.EmpresaId;
        }

    }
}

