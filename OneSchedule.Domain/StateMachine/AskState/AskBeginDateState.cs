using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskBeginDate")]
    public class AskBeginDateState : IState
    {
        private const string NextState = "GetBeginDate";
        private const string BotMessage = "Enter event start date and time:";
        private readonly ITelegramBotClient _bot;

        public AskBeginDateState(ITelegramBotClient bot)
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