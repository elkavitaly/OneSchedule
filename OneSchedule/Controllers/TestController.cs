using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        public TestController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            throw new AccessViolationException("Violation Exception while accessing the resource.");
        }
    }
}
