using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskShowEventList")]
    public class GetShowEventListState : BaseAskState
    {
        public GetShowEventListState(ITelegramBotClient bot) : base(bot)
        {
            NextState = "GetShowEventList";
            BotMessage = "Select option:";
        }

        public override async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            await base.HandleAsync(stateContext, dtoDomain);
            //show events buttons  (20 max)

            //show menu button
            throw new NotImplementedException();
        }
    }
}