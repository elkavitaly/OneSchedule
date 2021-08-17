using OneSchedule.Attributes;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using OneSchedule.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain
{
    [StateName("Initial")]
    public class InitialState : IState
    {
        private const string SetTitle = "SetTitle";
        private const string BotMessage = "Enter event title";
        private readonly ITelegramBotClient _bot;

        public InitialState(ITelegramBotClient bot)
        {
            _bot = bot;
        }

        public async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            await _bot.SendTextMessageAsync(dtoDomain.ChatId,BotMessage);
            stateContext.SetState(SetTitle);
        }
    }
}