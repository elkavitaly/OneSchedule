using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskNotifications")]
    public class AskNotificationsState : BaseAskState
    {
        private const string State = "AskNotifications";

        public AskNotificationsState(ITelegramBotClient bot) : base(bot)
        {
            BotMessage = "Enter event notifications: (1995-04-07T00:00:00 | 1995-04-07T00:00:00 | ...)";
        }

        public override async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            await base.HandleAsync(stateContext, dtoDomain);
            stateContext.ContextEntity.LastState = State;
        }
    }
}