using System;
using Apontamento.Empresa.Domain.Commands;
using FluentValidation;

namespace Apontamento.Empresa.Domain.Validations
{
    public class EmpresaValidation<T>: AbstractValidator<T> where T : EmpresaCommand
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



