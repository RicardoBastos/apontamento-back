using Apontamento.Shared.Controller;
using Apontamento.Usuario.Application.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Apontamento.Usuario.Api.Controller
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