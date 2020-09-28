using Apontamento.App.Empresa.Domain.Command;
using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;
using Apontamento.App.Shared.Domain;
using Apontamento.App.Shared.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Apontamento.App.Empresa.Handler
{
    public class EmpresaHandler : CommandHandler, IRequestHandler<EmpresaSalvarCommand, Response<Unit>>
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaHandler(IEmpresaRepository empresaRepository, IUnitOfWork uow):base(uow)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<Response<Unit>> Handle(EmpresaSalvarCommand request, CancellationToken cancellationToken)
        {
            Empresa.Domain.Empresa empresa = new Domain.Empresa();

            empresa.SetEmpresa(request.Id, request.Nome, request.Status);

            await _empresaRepository.Salvar(empresa);

            Commit();

            return new Response<Unit>(true, "Empresa salva com sucesso");
        }
    }
}
