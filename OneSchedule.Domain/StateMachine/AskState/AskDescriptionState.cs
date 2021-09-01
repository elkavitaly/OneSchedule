using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskDescription")]
    public class AskDescriptionState : BaseAskState
    {
        private const string State = "AskDescription";

        public AskDescriptionState(ITelegramBotClient bot) : base(bot)
        {
            BotMessage = "Enter event description";
        }

        public override async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            await base.HandleAsync(stateContext, dtoDomain);
            stateContext.ContextEntity.LastState = State;
        }
    }
}
