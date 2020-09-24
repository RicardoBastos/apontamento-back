using Apontamento.App.Empresa.Domain.Command;
using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace Apontamento.App.Empresa.Domain.Service
{
    public class EmpresaService : CommandHandler, IRequestHandler<EmpresaSalvarCmd, ValidationResult>, 
        IRequestHandler<EmpresaAtualizarCmd, ValidationResult>
    {
        private readonly Empresa empresa = new Empresa();

        private readonly IEmpresaRepository _empresaRepository;
        public IEmpresaDapperRepository _empresaDapperRepository { get; }

        public EmpresaService(IEmpresaRepository empresaRepository, IEmpresaDapperRepository empresaDapperRepository)
        {
            _empresaRepository = empresaRepository;
            _empresaDapperRepository = empresaDapperRepository;
        }

        public async Task<ValidationResult> Handle(EmpresaSalvarCmd request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            empresa.SetEmpresa(request.Id, request.Nome, request.Status);
            await _empresaRepository.Salvar(empresa);
            
            return ValidationResult;
        }

        public async Task<ValidationResult> Handle(EmpresaAtualizarCmd request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var retornoEmpresaQuery = await _empresaDapperRepository.BuscarEmpresaPorId(request.Id);

            if (retornoEmpresaQuery == null)
            {
                AddError("Empresa não foi encontrada");
                return ValidationResult;
            }

            empresa.SetEmpresa(request.Id, request.Nome, request.Status);
            _empresaRepository.Atualizar(empresa);

            return ValidationResult;
        }
    }
}
