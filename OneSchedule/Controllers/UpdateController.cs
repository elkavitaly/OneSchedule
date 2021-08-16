using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.Models;
using OneSchedule.Domain.Models.Strategies;
using System;
using Telegram.Bot.Types;

namespace OneSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        private readonly StrategyContext _context;

        public UpdateController(IService<UserDomain> service, IMapper mapper, StrategyContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Post([FromBody] Update[] updates)
        {
            foreach (var update in updates)
            {
                Console.WriteLine("____________");
                Console.WriteLine(update.Id);
                Console.WriteLine(update.Type);
                Console.WriteLine(update.Message.Text);
                Console.WriteLine($" chat : {update.Message.Chat.Id}");
                Console.WriteLine(update.Message.MessageId);
                Console.WriteLine("____________");
            }
        }
    }
}
