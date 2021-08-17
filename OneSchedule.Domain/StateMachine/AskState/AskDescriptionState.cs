using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskDescription")]
    public class AskDescriptionState : IState
    {
        private const string SetNotifications = "GetDescription";
        private const string BotMessage = "Enter event description";
        private readonly ITelegramBotClient _bot;

        public AskDescriptionState(ITelegramBotClient bot)
        {
            _bot = bot;
        }

        public async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            await _bot.SendTextMessageAsync(dtoDomain.ChatId, BotMessage);
            stateContext.SetState(SetNotifications);
        }
    }
}
