using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskEndDate")]
    public class AskEndDateState : IState
    {
        private const string NextState = "GetEndDate";
        private const string BotMessage = "Enter event end date and time:";
        private readonly ITelegramBotClient _bot;

        public AskEndDateState(ITelegramBotClient bot)
        {
            _bot = bot;
        }

        public async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            await _bot.SendTextMessageAsync(dtoDomain.ChatId, BotMessage);
            stateContext.SetState(NextState);
        }
    }
}