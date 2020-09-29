using Apontamento.App.Empresa.Application.Domain.Command;
using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;
using Apontamento.App.Shared.Domain;
using Apontamento.App.Shared.Interfaces.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Apontamento.App.Empresa.Application.Domain.Handler
{
    public class EmpresaHandler : 
        CommandHandler, 
        IRequestHandler<EmpresaSalvarCommand, Response<Unit>>, 
        IRequestHandler<EmpresaAtualizarCommand, Response<Unit>>
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaHandler(IEmpresaRepository empresaRepository, IUnitOfWork uow):base(uow)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<Response<Unit>> Handle(EmpresaSalvarCommand request, CancellationToken cancellationToken)
        {
            Empresa empresa = new Domain.Empresa();

            empresa.SetEmpresa(request.Id, request.Nome, request.Status);

            await _empresaRepository.Salvar(empresa);

            Commit();

            return new Response<Unit>(true, "Empresa salva com sucesso");
        }

        public async Task<Response<Unit>> Handle(EmpresaAtualizarCommand request, CancellationToken cancellationToken)
        {
            Empresa empresa = new Empresa();

            empresa.SetEmpresa(request.Id, request.Nome, request.Status);

            _empresaRepository.Atualizar(empresa);

            Commit();

            return await Task.FromResult(new Response<Unit>(true, "Empresa atualizada com sucesso"));
        }
    }
}
