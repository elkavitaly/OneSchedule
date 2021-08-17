using OneSchedule.Attributes;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskTitle")]
    public class AskTitleState : BaseAskState
    {
        public AskTitleState(ITelegramBotClient bot) : base(bot)
        {
            NextState = "GetTitle";
            BotMessage = "Enter event title:";
        }
    }
}