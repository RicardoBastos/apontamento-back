using Apontamento.App.Empresa.Application.Interface;
using Apontamento.App.Empresa.Domain.Command;
using Apontamento.App.Shared.Domain;
using Apontamento.App.Shared.Interfaces.Repository;
using FluentValidation.Results;
using MediatR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Apontamento.App.Empresa.Application
{
    public class EmpresaApplication: IEmpresaApplication
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _uow;

        public EmpresaApplication(IMediator mediator, IUnitOfWork uow)
        {
            _mediator = mediator;
            _uow = uow;
        }


        public async Task<Result> SalvarEmpresa(EmpresaSalvarCmd empresaSalvarCmd)
        {
            var retornoSalvarEmpresa = await _mediator.Send<ValidationResult>(empresaSalvarCmd);

            if (retornoSalvarEmpresa.Errors.Count > 0) {
                return new Result() {Errors = retornoSalvarEmpresa.Errors.Select(err => err.ErrorMessage).ToList() }; 
            }

            _uow.Commit();
            return new Result() { Mensagem = "Empresa salva com sucesso" };
        }

        public async Task<Result> AtualizarEmpresa(EmpresaAtualizarCmd empresaAtualizarCmd)
        {
            var retornoAtualizarEmpresa = await _mediator.Send<ValidationResult>(empresaAtualizarCmd);

            if (retornoAtualizarEmpresa.Errors.Count > 0)
            {
                return new Result() { Errors = retornoAtualizarEmpresa.Errors.Select(err => err.ErrorMessage).ToList() };
            }

            _uow.Commit();
            return new Result() { Mensagem = "Empresa atualizada com sucesso" };
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
