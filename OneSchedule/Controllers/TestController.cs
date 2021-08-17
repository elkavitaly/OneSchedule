using Microsoft.AspNetCore.Mvc;

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
