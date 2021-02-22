using Apontamento.Shared.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Apontamento.Shared.Controller
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


