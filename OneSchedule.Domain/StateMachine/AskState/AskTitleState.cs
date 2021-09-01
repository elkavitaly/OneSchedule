using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskTitle")]
    public class AskTitleState : BaseAskState
    {
        private const string State = "AskTitle";

        public AskTitleState(ITelegramBotClient bot) : base(bot)
        {
            BotMessage = "Enter event title:";
        }

        public override async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            await base.HandleAsync(stateContext, dtoDomain);
            stateContext.ContextEntity.LastState = State;
        }
    }
}