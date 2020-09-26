using Apontamento.App.Shared.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Apontamento.App.Shared.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
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


