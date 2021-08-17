using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskEventMenu")]
    public class AskEventMenuState : BaseAskState
    {
        public AskEventMenuState(ITelegramBotClient bot):base(bot)
        {
            NextState = "GetEventMenu";
            BotMessage = "Select option:";
        }

        public override async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            await Bot.SendTextMessageAsync(dtoDomain.ChatId, BotMessage);

            // show menu buttons

            if (string.IsNullOrWhiteSpace(stateContext.EventEntity.Id))
            {
                // Add delete button 
            }
            
            stateContext.SetState(NextState);
            throw new NotImplementedException();
        }
    }
}