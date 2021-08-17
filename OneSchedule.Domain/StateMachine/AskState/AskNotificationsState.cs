using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskNotifications")]
    public class AskNotificationsState : IState
    {
        private const string NextState = "GetNotifications";
        private const string BotMessage = "Enter event notifications([date1] [date2]...):";
        private readonly ITelegramBotClient _bot;

        public AskNotificationsState(ITelegramBotClient bot)
        {
            _bot = bot;
        }

        public async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            await _bot.SendTextMessageAsync(dtoDomain.ChatId, BotMessage);
            stateContext.SetState(NextState);
        }
    }
}