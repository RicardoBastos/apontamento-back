using Apontamento.App.Shared.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Apontamento.App.Shared.Controller
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();



        protected IActionResult SuccessOrBad(Response<Unit> result)
        {
            if (!result.Succeeded){ return BadRequest(result); }
            return Ok(result);
        }
    }
}


