
using Apontamento.App.Empresa.Application.Domain;
using Apontamento.App.Empresa.Application.Command;
using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;
using Apontamento.App.Shared.Controller;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Apontamento.App.Empresa.Api.Controller
{
    public class EmpresasController : BaseApiController
    {
        private readonly IEmpresaDapperRepository _empresaDapperRepository;


        public EmpresasController(IEmpresaDapperRepository empresaDapperRepository)
        {
            _empresaDapperRepository = empresaDapperRepository ?? throw new ArgumentNullException(nameof(empresaDapperRepository));
          
        }

        [HttpGet(Routes.Empresa.BuscarEmpresasPaginada)]
        public async Task<IActionResult> Get([FromQuery]Paginacao paginacao, [FromQuery]string nome, [FromQuery]EnumStatus status = EnumStatus.Todos)
        {
            return Ok(await _empresaDapperRepository.BuscarEmpresasPaginada(nome, status, paginacao));
        }

        [HttpGet(Routes.Empresa.BuscarEmpresaPorId)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _empresaDapperRepository.BuscarEmpresaPorId(id));
        }


        [HttpPost(Routes.Empresa.SalvarEmpresa)]
        public async Task<IActionResult> PostAsync([FromBody]EmpresaSalvarCommand empresa)
        {
            return SuccessOrBad(await Mediator.Send(empresa));
        }



        [HttpPut(Routes.Empresa.AtualizarEmpresa)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody]EmpresaAtualizarCommand empresa)
        {
            empresa.SetId(id);
            return Ok(await Mediator.Send(empresa));
        }

    }
}