using System;
using Apontamento.App.Empresa.Domain.Command;
using FluentValidation;

namespace Apontamento.App.Empresa.Domain.Validations
{
    public class EmpresaValidation<T>: AbstractValidator<T> where T : EmpresaCmd
    {
    
        public void ValidarId()
        {
            RuleFor(empresa => empresa.Id)
                .NotNull().NotEqual(Guid.Empty).WithMessage("O Id é obrigatório");
        }

        public void ValidarNome()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(100).WithMessage("Nome permitido até 100 caracteres");
        }
    }
}
