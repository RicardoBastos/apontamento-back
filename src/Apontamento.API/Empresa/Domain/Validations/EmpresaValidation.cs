using System;
using System.Threading;
using System.Threading.Tasks;
using Apontamento.App.Empresa.Domain.Command;
using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;
using FluentValidation;

namespace Apontamento.App.Empresa.Domain.Validations
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



