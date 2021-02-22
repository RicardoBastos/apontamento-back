
using Apontamento.Empresa.Domain.Commands;
using Apontamento.Empresa.Infrastructure.Repository.Interfaces;
using Apontamento.Projeto.Infrastructure.Repository.Interfaces;
using Apontamento.Shared.Domain;
using Apontamento.Shared.Interfaces.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Apontamento.Empresa.Domain.Handlers
{
    public class EmpresaHandler :
        CommandHandler,
        IRequestHandler<EmpresaSalvarCommand, Response<Unit>>, 
        IRequestHandler<EmpresaAtualizarCommand, Response<Unit>>
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IProjetoRepository projetoRepository;
        private readonly Entities.Empresa empresa = new Entities.Empresa();
        private readonly Response<Unit> retorno = new Response<Unit>();
        private readonly IMediator _mediator;

        public EmpresaHandler(IEmpresaRepository empresaRepository, IProjetoRepository projetoRepository,IMediator mediator, IUnitOfWork uow) : base(uow)
        {
            _empresaRepository = empresaRepository;
            this.projetoRepository = projetoRepository;
            _mediator = mediator;
        }

        public async Task<Response<Unit>> Handle(EmpresaSalvarCommand request, CancellationToken cancellationToken)
        {
            empresa.SetEmpresa(request);

            #region Exemplos
            //Exemplo de Validacao
            //if (request.Nome == "ricardo")
            //{
            //    return FormatarErroParaRetorno("Nome eh ricardo");
            //}

            //Exemplo de EventHandler
            //await _mediator.Publish(new EmpresaSalvarNotification() { Nome="Jose", Id=empresa.Id });

            //Exemplo de chamar novo handler
            //await _mediator.Send(new ProjetoSalvarCommand() { Nome = "Teste", EmpresaId = empresa.Id, Horas = 2 });
            #endregion

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
