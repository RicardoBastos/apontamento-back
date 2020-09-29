using Apontamento.App.Shared.Controller;
using Apontamento.App.Usuario.Application.Domain.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Apontamento.App.Usuario.Api.Controller
{

    public class UsuariosController : BaseApiController
    {
        public UsuariosController()
        {

        }


        [AllowAnonymous]
        [HttpPost(Routes.Usuario.Autenticar)]
        public async Task<IActionResult> Autenticar([FromBody]AutenticarCommand usuario)
        {
            return Ok(await Mediator.Send(usuario));
        }

    }
}