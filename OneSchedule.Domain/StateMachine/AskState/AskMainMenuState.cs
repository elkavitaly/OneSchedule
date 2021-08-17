using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskMainMenu")]
    public class AskMainMenuState : IState
    {
        private const string NextState = "GetMainMenu";
        private const string BotMessage = "Select option:";
        private readonly ITelegramBotClient _bot;

        public AskMainMenuState(ITelegramBotClient bot)
        {
            _bot = bot;
        }

        public async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            await _bot.SendTextMessageAsync(dtoDomain.ChatId, BotMessage);
            // show menu buttons
            stateContext.SetState(NextState);
            throw new NotImplementedException();
        }
    }
}