
using Apontamento.App.Projeto.Domain;
using Apontamento.App.Projeto.Application.Command;
using Apontamento.App.Projeto.Infrastructure.Repository.Interfaces;
using Apontamento.App.Shared.Controller;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Apontamento.App.Projeto.Api.Controller
{
    public class ProjetosController : BaseApiController
    {
        private readonly IProjetoDapperRepository _projetoDapperRepository;


        public ProjetosController(IProjetoDapperRepository ProjetoDapperRepository)
        {
            _projetoDapperRepository = ProjetoDapperRepository ?? throw new ArgumentNullException(nameof(ProjetoDapperRepository));
          
        }

        [HttpGet(Routes.Projeto.BuscarProjetosPaginada)]
        public async Task<IActionResult> Get([FromQuery]Paginacao paginacao, [FromQuery]string nome, [FromQuery]Guid empresaId)
        {
            return Ok(await _projetoDapperRepository.BuscarProjetosPaginada(nome, empresaId, paginacao));
        }

        [HttpGet(Routes.Projeto.BuscarProjetoPorId)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _projetoDapperRepository.BuscarProjetoPorId(id));
        }


        [HttpPost(Routes.Projeto.SalvarProjeto)]
        public async Task<IActionResult> PostAsync([FromBody]ProjetoSalvarCommand Projeto)
        {
            return SuccessOrBad(await Mediator.Send(Projeto));
        }



        [HttpPut(Routes.Projeto.AtualizarProjeto)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody]ProjetoAtualizarCommand Projeto)
        {
            Projeto.SetId(id);
            return Ok(await Mediator.Send(Projeto));
        }

    }
}