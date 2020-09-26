using Apontamento.App.Empresa.Domain.Validations;
using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;
using FluentValidation.Results;
using System;

namespace Apontamento.App.Empresa.Domain.Command
{
    public class EmpresaAtualizarCmd : EmpresaCmd
    {
        public EmpresaAtualizarCmd() { }

        public EmpresaAtualizarCmd(Guid id, string nome, bool status)
        {
            this.Id = id;
            this.Nome = nome;
            this.Status = status;

        }

        public virtual bool IsValid(IEmpresaDapperRepository empresaDapperRepository)
        {
            ValidationResult = new EmpresaAtualizarValidation(empresaDapperRepository).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
