using Apontamento.App.Empresa.Domain.Validations;
using FluentValidation.Results;
using System;

namespace Apontamento.App.Empresa.Domain.Command
{
    public class EmpresaSalvarCmd : EmpresaCmd
    {
        public EmpresaSalvarCmd()
        {
            Id = Guid.NewGuid();
        }

        public EmpresaSalvarCmd(string nome, bool status)
        {
            this.Nome = nome;
            this.Status = status;

        }

        public virtual bool IsValid()
        {
            ValidationResult = new EmpresaSalvarValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
