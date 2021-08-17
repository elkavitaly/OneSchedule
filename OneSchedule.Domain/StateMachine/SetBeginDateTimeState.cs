using OneSchedule.Attributes;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using OneSchedule.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain
{
    [StateName("SetBeginDateTime")]
    public class SetBeginDateTimeState : IState
    {
        private const string SetEndDateTime = "SetEndDateTime";
        private const string BotMessage = "Enter event end date and time";
        private readonly ITelegramBotClient _bot;

        public SetBeginDateTimeState(ITelegramBotClient bot)
        {
            _bot = bot;
        }

        public async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            stateContext.EventEntity.StartDate = DateTime.Parse(dtoDomain.MessageText);
            await _bot.SendTextMessageAsync(dtoDomain.ChatId, BotMessage);
            stateContext.SetState(SetEndDateTime);
        }
    }
}