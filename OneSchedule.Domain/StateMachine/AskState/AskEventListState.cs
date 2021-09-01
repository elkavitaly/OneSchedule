using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskEventList")]
    public class AskEventListState : BaseAskState
    {
        private const string State = "AskEventList";

        public AskEventListState(ITelegramBotClient bot) : base(bot)
        {
            BotMessage = "Enter interval (1995-04-07T00:00:00 | 1995-06-07T00:00:00):";
        }

        public override async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            await base.HandleAsync(stateContext, dtoDomain);
            stateContext.ContextEntity.LastState = State;
        }
    }
}