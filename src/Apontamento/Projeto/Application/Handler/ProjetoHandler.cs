using Apontamento.Projeto.Application.Command;
using Apontamento.Projeto.Infrastructure.Repository.Interfaces;
using Apontamento.Shared.Domain;
using Apontamento.Shared.Interfaces.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Apontamento.Projeto.Application.Handler
{
    public class ProjetoHandler :
        CommandHandler,
        IRequestHandler<ProjetoSalvarCommand, Response<Unit>>, 
        IRequestHandler<ProjetoAtualizarCommand, Response<Unit>>
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly Domain.Projeto projeto = new Domain.Projeto();
        private readonly Response<Unit> retorno = new Response<Unit>();

        public ProjetoHandler(IProjetoRepository ProjetoRepository, IUnitOfWork uow) : base(uow)
        {
            _projetoRepository = ProjetoRepository;
        }

        public async Task<Response<Unit>> Handle(ProjetoSalvarCommand request, CancellationToken cancellationToken)
        {
            projeto.SetProjeto(request);

            //if (request.Nome == "ricardo")
            //{
            //    return FormatarErroParaRetorno("Nome eh ricardo");
            //}
            try
            {
                await _projetoRepository.Salvar(projeto);

                Commit();
            }
            catch (Exception ex)
            {
                var xx = ex.Message;
                throw;
            }
          

            return retorno.ResponseMessage("Projeto salvo com sucesso",true);
        }

        public async Task<Response<Unit>> Handle(ProjetoAtualizarCommand request, CancellationToken cancellationToken)
        {
            projeto.SetProjeto(request);

            await _projetoRepository.Atualizar(projeto);

            //await _uow.Commit();

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
