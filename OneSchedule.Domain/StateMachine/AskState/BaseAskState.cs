using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    public abstract class BaseAskState : IState
    {
        protected readonly ITelegramBotClient Bot;

        protected string BotMessage { get; set; }

        protected string NextState { get; set; }

        protected BaseAskState(ITelegramBotClient bot)
        {
            Bot = bot;
        }

        public virtual async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            await Bot.SendTextMessageAsync(dtoDomain.ChatId, BotMessage);
            stateContext.SetState(NextState);
        }
    }
}
