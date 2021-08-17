using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.Models;
using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine
{
    [StateName("SetDescription")]
    public class SetDescriptionState : IState
    {
        private const string SetNotifications = "SetNotifications";
        private const string BotMessage = "Enter event description";
        private readonly ITelegramBotClient _bot;

        public SetDescriptionState(ITelegramBotClient bot)
        {
            _bot = bot;
        }

        public async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            stateContext.EventEntity.Description = dtoDomain.MessageText;
            await _bot.SendTextMessageAsync(dtoDomain.ChatId, BotMessage);
            stateContext.SetState(SetNotifications);
        }
    }
}
