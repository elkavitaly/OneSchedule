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
        private IStateMachineState _state;
        private IServiceProvider _serviceProvider;

        public TestController(IStateMachineContext stateMachineContext, IStateMachineState stateMachineState,
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
            StateMachineContext context = (StateMachineContext)_context;

            context.Bot.SendTextMessageAsync(-1001553215565, "test state machine context bot injection");

            return null;
            throw new BotAppInternalException("This is bot internal app exception");
        }
    }
}
