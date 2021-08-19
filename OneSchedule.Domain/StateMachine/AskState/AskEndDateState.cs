using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskEndDate")]
    public class AskEndDateState : BaseAskState
    {
        private const string State = "AskEndDate";

        public AskEndDateState(ITelegramBotClient bot) : base(bot)
        {
            BotMessage = "Enter event end date and time: (1995-04-07T00:00:00)";
        }

        public override async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            await base.HandleAsync(stateContext, dtoDomain);
            stateContext.ContextEntity.LastState = State;
        }
    }
}