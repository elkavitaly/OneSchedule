using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OneScheduleTelegram;
using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;


namespace OneSchedule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UpdatesController : ControllerBase
    {
        private readonly ILogger<UpdatesController> _logger;
        private readonly TelegramRepository _repository;

        public UpdatesController(ILogger<UpdatesController> logger)
        {
            _logger = logger;
            _repository = new TelegramRepository();
        }

        [HttpGet]
        public IEnumerable<Update> Get()
        {
            return _repository.GetUpdates(0);
        }
    }
}
