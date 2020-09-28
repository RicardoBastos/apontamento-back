using Apontamento.App.Shared.Controller;
using Apontamento.App.Usuario.Application.Interface;
using Apontamento.App.Usuario.Domain.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Apontamento.App.Usuario.Api.Controller
{

    public class UsuariosController : BaseController
    {
        private readonly ISessionApplication _sessionApplication;

        public UsuariosController(ISessionApplication sessionApplication)
        {
            this._sessionApplication = sessionApplication;
        }

      
        [AllowAnonymous]
        [HttpPost(Routes.Usuario.Autenticar)]
        public async Task<IActionResult> Autenticar([FromBody]SessionUsuarioCmd usuario)
        {
            var result = await _sessionApplication.Autenticar(usuario);
            return SuccessOrBad(result);
        }

    }
}