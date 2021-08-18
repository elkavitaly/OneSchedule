using OneSchedule.Attributes;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskEventList")]
    public class AskEventListState : BaseAskState
    {
        public AskEventListState(ITelegramBotClient bot) : base(bot)
        {
            NextState = "GetEventList";
            BotMessage = "Enter interval ([min events start date] - [max events start date]):";
        }
    }
}