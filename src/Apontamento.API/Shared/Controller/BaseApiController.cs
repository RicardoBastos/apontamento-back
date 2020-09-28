using Apontamento.App.Shared.Domain;
using MediatR;
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


        protected IActionResult CreatedOrBad(Result result)
        {
            if (result.hasErrors) return BadRequest(result);

            return Created(string.Empty,result);
        }
    

        protected IActionResult UpdatedOrBad(Result result)
        {
            if (result.hasErrors) return BadRequest(result);
            
            return Accepted(result);
        }


        protected IActionResult SuccessOrBad(Result result)
        {
            if (result.hasErrors) return BadRequest(result);

            return Ok(result);
        }
    }

   

}


