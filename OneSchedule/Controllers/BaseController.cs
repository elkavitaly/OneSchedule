using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace OneSchedule.Controllers
{
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        protected ActionResult OkOrNotFound<Tdto>(Tdto dto)
        {
            if (dto is null
                || typeof(IEnumerable<object>).IsAssignableFrom(typeof(Tdto))
                    && ((IEnumerable<dynamic>)dto).Count() == 0)
            {
                return NotFound();
            }

            return Ok(dto);
        }
    }
}
