using OneSchedule.Attributes;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskEndDate")]
    public class AskEndDateState : BaseAskState
    {
        public AskEndDateState(ITelegramBotClient bot) : base(bot)
        {
            NextState = "GetEndDate";
            BotMessage = "Enter event end date and time:";
        }
    }
}