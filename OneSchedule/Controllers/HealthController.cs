using Microsoft.AspNetCore.Mvc;

namespace OneSchedule.Controllers
{
    [Route("[Controller]")]
    public class HealthController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("I am alive");
        }
    }
}
