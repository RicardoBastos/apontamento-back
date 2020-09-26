using System;
using Apontamento.App.Empresa.Domain.Command;
using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;
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

        public void ValidarNome(IEmpresaDapperRepository empresaDapperRepository)
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(100).WithMessage("Nome permitido até 100 caracteres");

            RuleFor(cmdEmpresa => cmdEmpresa).MustAsync(async (cmdEmpresa, cancellation) => {
                var existe =  await empresaDapperRepository.BuscarEmpresaPorNome(cmdEmpresa.Nome, cmdEmpresa.Id);
                return existe == null;
            }).WithMessage("Já existe uma empresa com esse nome");
        }

    }
}
