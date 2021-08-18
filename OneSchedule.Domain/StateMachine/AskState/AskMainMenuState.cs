using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskMainMenu")]
    public class AskMainMenuState : BaseAskState
    {
        public AskMainMenuState(ITelegramBotClient bot) : base(bot)
        {
            NextState = "GetMainMenu";
            BotMessage = "Select option:";
        }

        public override async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            await base.HandleAsync(stateContext, dtoDomain);
            // show menu buttons
            throw new NotImplementedException();
        }
    }
}