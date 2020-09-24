using Apontamento.App.Empresa.Application.Interface;
using Apontamento.App.Empresa.Domain.Command;
using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;
using Apontamento.App.Shared.Controller;
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
        public async Task<IActionResult> GetAsync()
        {
            var objRetorno = await _empresaDapperRepository.BuscarEmpresasPaginada();
            return Ok(objRetorno);
        }


        [HttpPost(Routes.Empresa.SalvarEmpresa)]
        public async Task<IActionResult> PostAsync([FromBody]EmpresaSalvarCmd empresa)
        {
            var result = await _empresaApplication.SalvarEmpresa(empresa);
            return CreatedOrBad(result);
        }


        [HttpPost(Routes.Empresa.AtualizarEmpresa)]
        public async Task<IActionResult> Put(Guid Id, [FromBody]EmpresaAtualizarCmd empresa)
        {
            empresa.SetId(Id);
            var result = await _empresaApplication.AtualizarEmpresa(empresa);
            return UpdatedOrBad(result);
        }

    }
}