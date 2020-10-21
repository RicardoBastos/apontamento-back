using Apontamento.App.Projeto.Application.Command;
using Apontamento.App.Projeto.Infrastructure.Repository.Interfaces;
using Apontamento.App.Shared.Domain;
using Apontamento.App.Shared.Interfaces.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Apontamento.App.Projeto.Application.Handler
{
    public class ProjetoHandler : 
        CommandHandler, 
        IRequestHandler<ProjetoSalvarCommand, Response<Unit>>, 
        IRequestHandler<ProjetoAtualizarCommand, Response<Unit>>
    {
        private readonly IProjetoRepository _projetoRepository;

        private readonly Domain.Projeto Projeto = new Domain.Projeto();
        private readonly Response<Unit> retorno = new Response<Unit>();

        public ProjetoHandler(IProjetoRepository ProjetoRepository, IUnitOfWork uow):base(uow)
        {
            _projetoRepository = ProjetoRepository;

        }

        public async Task<Response<Unit>> Handle(ProjetoSalvarCommand request, CancellationToken cancellationToken)
        {
            Projeto.SetProjeto(request);

            //if (request.Nome == "ricardo")
            //{
            //    return FormatarErroParaRetorno("Nome eh ricardo");
            //}

            await _projetoRepository.Salvar(Projeto);

            Commit();

            return retorno.ResponseMessage("Projeto salvo com sucesso",true);
        }

        public async Task<Response<Unit>> Handle(ProjetoAtualizarCommand request, CancellationToken cancellationToken)
        {
            Projeto.SetProjeto(request);

            await _projetoRepository.Atualizar(Projeto);

            Commit();

            return retorno.ResponseMessage("Projeto atualizado com sucesso");
        }

        public Response<Unit> FormatarErroParaRetorno(string mensagem)
        {
            retorno.Errors.Add(mensagem);
            retorno.ResponseMessage("Erro de validação", false);
            return retorno;
        }
    }
}
