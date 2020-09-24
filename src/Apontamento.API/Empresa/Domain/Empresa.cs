using Apontamento.App.Shared.Domain;
using System;

namespace Apontamento.App.Empresa.Domain
{
    public class Empresa : Base
    {
        public Empresa()
        {

        }

        public string Nome { get; private set; }
        public bool Status { get; private set; }

        public void SetEmpresa(Guid id, string nome, bool status)
        {
            this.Id = id;
            this.Nome = nome;
            this.Status = status;
        }

    }
}

