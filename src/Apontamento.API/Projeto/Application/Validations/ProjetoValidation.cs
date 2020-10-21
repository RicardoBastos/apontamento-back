using System;
using Apontamento.App.Projeto.Application.Command;
using FluentValidation;

namespace Apontamento.App.Projeto.Application.Validations
{
    public class ProjetoValidation<T>: AbstractValidator<T> where T : ProjetoCommand
    {

        public void ValidarId()
        {
            RuleFor(Projeto => Projeto.Id)
                 .NotNull().NotEqual(Guid.Empty).WithMessage("O Id é obrigatório");

        }

        public void ValidarNome()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(100).WithMessage("Nome permitido até 100 caracteres");
        }


        public void ValidarEmpresa()
        {
            RuleFor(p => p.EmpresaId)
                .NotNull().NotEqual(Guid.Empty).WithMessage("Empresa é obrigatório");

        }


    }

}



