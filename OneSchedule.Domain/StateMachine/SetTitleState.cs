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
    [StateName("SetTitle")]
    public class SetTitleState : IState
    {
        private const string SetBeginDateTime = "SetBeginDateTime";
        private const string BotMessage = "Enter event begin date and time";
        private readonly ITelegramBotClient _bot;

        public SetTitleState(ITelegramBotClient bot)
        {
            _bot = bot;
        }

        public async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            stateContext.EventEntity.Title = dtoDomain.MessageText;
            await _bot.SendTextMessageAsync(dtoDomain.ChatId, BotMessage);
            stateContext.SetState(SetBeginDateTime);
        }
    }
}