using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskBeginDate")]
    public class AskBeginDateState : BaseAskState
    {
        private const string State = "AskBeginDate";

        public AskBeginDateState(ITelegramBotClient bot) : base(bot)
        {
            BotMessage = "Enter event start date and time: (1995-04-07T00:00:00)";
        }

        public override async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            await base.HandleAsync(stateContext, dtoDomain);
            stateContext.ContextEntity.LastState = State;
        }
    }
}