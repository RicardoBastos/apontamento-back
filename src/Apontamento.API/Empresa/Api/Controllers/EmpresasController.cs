
using Apontamento.App.Empresa.Domain;
using Apontamento.App.Empresa.Domain.Command;
using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;
using Apontamento.App.Shared.Controller;
using Apontamento.App.Shared.Domain;
using Apontamento.App.Usuario.Application.Interface;
using MediatR;
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
            var objRetorno = await _empresaDapperRepository.BuscarEmpresasPaginada(nome,status,paginacao);
            return Ok(objRetorno);
        }


        [HttpPost(Routes.Empresa.SalvarEmpresa)]
        public async Task<IActionResult> PostAsync([FromBody]EmpresaSalvarCommand empresa)
        {
            return Ok(await Mediator.Send(empresa));
        }


        //[HttpPut(Routes.Empresa.AtualizarEmpresa)]
        //public async Task<IActionResult> Put(Guid id, [FromBody]EmpresaAtualizarCmd empresa)
        //{
        //    empresa.SetId(id);
        //    var result = await _empresaApplication.AtualizarEmpresa(empresa);
        //    return UpdatedOrBad(result);
        //}

    }
}