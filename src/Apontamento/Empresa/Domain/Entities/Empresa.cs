using Apontamento.Empresa.Domain.Commands;
using Apontamento.Shared.Domain;
using System.Collections.Generic;

namespace Apontamento.Empresa.Domain.Entities
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

