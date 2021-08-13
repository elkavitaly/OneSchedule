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

        [HttpPost]
        public IActionResult Post()
        {
            return null;
        }

        [HttpGet]
        public IActionResult Get()
        {
            throw new BotAppInternalException("This is bot internal app exception");
        }
    }
}
