using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OneSchedule.Domain;
using OneSchedule.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IStateMachineContext _context;
        private IState _state;
        private IServiceProvider _serviceProvider;

        public TestController(IStateMachineContext stateMachineContext, IState stateMachineState,
                                IServiceProvider serviceProvider)
        {
            _context = stateMachineContext;
            _state = stateMachineState;
            _serviceProvider = serviceProvider;
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
