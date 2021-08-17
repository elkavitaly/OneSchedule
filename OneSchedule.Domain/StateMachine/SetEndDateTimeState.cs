using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.Models;
using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine
{
    [StateName("SetEndDateTime")]
    public class SetEndDateTimeState : IState
    {
        private const string SetDescription = "SetDescription";
        private const string BotMessage = "Enter event description";
        private readonly ITelegramBotClient _bot;

        public SetEndDateTimeState(ITelegramBotClient bot)
        {
            _bot = bot;
        }

        public async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            stateContext.EventEntity.EndDate = DateTime.Parse(dtoDomain.MessageText);
            await _bot.SendTextMessageAsync(dtoDomain.ChatId, BotMessage);
            stateContext.SetState(SetDescription);
        }
    }
}
