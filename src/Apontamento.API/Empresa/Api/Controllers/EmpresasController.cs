using Apontamento.App.Empresa.Application.Interface;
using Apontamento.App.Empresa.Domain;
using Apontamento.App.Empresa.Domain.Command;
using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;
using Apontamento.App.Shared.Controller;
using Apontamento.App.Usuario.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Apontamento.App.Empresa.Api.Controller
{
    public class EmpresasController : BaseController
    {
        private readonly IEmpresaDapperRepository _empresaDapperRepository;
        public IEmpresaApplication _empresaApplication { get; }
        public EmpresasController(IEmpresaDapperRepository empresaDapperRepository,
            IEmpresaApplication empresaApplication) :base()
        {
            _empresaDapperRepository = empresaDapperRepository ?? throw new ArgumentNullException(nameof(empresaDapperRepository));
            _empresaApplication = empresaApplication;
            
        }

       

        [HttpGet(Routes.Empresa.BuscarEmpresasPaginada)]
        public async Task<IActionResult> Get([FromQuery]Paginacao paginacao, [FromQuery]string nome, [FromQuery]EnumStatus status = EnumStatus.Todos)
        {
            var objRetorno = await _empresaDapperRepository.BuscarEmpresasPaginada(nome,status,paginacao);
            return Ok(objRetorno);
        }


        [HttpPost(Routes.Empresa.SalvarEmpresa)]
        public async Task<IActionResult> PostAsync([FromBody]EmpresaSalvarCmd empresa)
        {
            var result = await _empresaApplication.SalvarEmpresa(empresa);
            return CreatedOrBad(result);
        }


        [HttpPut(Routes.Empresa.AtualizarEmpresa)]
        public async Task<IActionResult> Put(Guid id, [FromBody]EmpresaAtualizarCmd empresa)
        {
            empresa.SetId(id);
            var result = await _empresaApplication.AtualizarEmpresa(empresa);
            return UpdatedOrBad(result);
        }

    }
}