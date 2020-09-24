using Apontamento.App.Empresa.Domain.Validations;
using FluentValidation.Results;
using System;

namespace Apontamento.App.Empresa.Domain.Command
{
    public class EmpresaAtualizarCmd : EmpresaCmd
    {
        public EmpresaAtualizarCmd()
        {
            Id = Guid.NewGuid();
        }

        public EmpresaAtualizarCmd(string nome, bool status)
        {
            this.Nome = nome;
            this.Status = status;

        }

        public virtual bool IsValid()
        {
            ValidationResult = new EmpresaAtualizarValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
