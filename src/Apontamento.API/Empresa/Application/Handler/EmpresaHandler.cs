using Apontamento.App.Empresa.Application.Command;
using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;
using Apontamento.App.Shared.Domain;
using Apontamento.App.Shared.Interfaces.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Apontamento.App.Empresa.Application.Handler
{
    public class EmpresaHandler : 
        CommandHandler, 
        IRequestHandler<EmpresaSalvarCommand, Response<Unit>>, 
        IRequestHandler<EmpresaAtualizarCommand, Response<Unit>>
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly Empresa.Domain.Empresa empresa = new Empresa.Domain.Empresa();
        private readonly Response<Unit> retorno = new Response<Unit>();

        public EmpresaHandler(IEmpresaRepository empresaRepository, IUnitOfWork uow):base(uow)
        {
            _empresaRepository = empresaRepository;

        }

        public async Task<Response<Unit>> Handle(EmpresaSalvarCommand request, CancellationToken cancellationToken)
        {
            empresa.SetEmpresa(request);

            //if (request.Nome == "ricardo")
            //{
            //    return FormatarErroParaRetorno("Nome eh ricardo");
            //}

            await _empresaRepository.Salvar(empresa);

            Commit();

            return retorno.ResponseMessage("Empresa salva com sucesso",true);
        }

        public async Task<Response<Unit>> Handle(EmpresaAtualizarCommand request, CancellationToken cancellationToken)
        {
            empresa.SetEmpresa(request);

            await _empresaRepository.Atualizar(empresa);

            Commit();

            return retorno.ResponseMessage("Empresa atualizada com sucesso");
        }

        public Response<Unit> FormatarErroParaRetorno(string mensagem)
        {
            retorno.Errors.Add(mensagem);
            retorno.ResponseMessage("Erro de validação", false);
            return retorno;
        }
    }
}
