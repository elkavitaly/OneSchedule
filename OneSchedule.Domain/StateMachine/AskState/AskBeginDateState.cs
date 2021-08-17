using OneSchedule.Attributes;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskBeginDate")]
    public class AskBeginDateState : BaseAskState
    {
        public AskBeginDateState(ITelegramBotClient bot) : base(bot)
        {
            NextState = "GetBeginDate";
            BotMessage = "Enter event start date and time:";
        }
    }
}