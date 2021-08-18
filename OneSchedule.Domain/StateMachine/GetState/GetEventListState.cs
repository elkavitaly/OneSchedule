using OneSchedule.Attributes;
using OneSchedule.Domain.StateMachine.AskState;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.GetState
{
    [StateName("GetEventList")]
    public class GetEventListState : BaseAskState
    {
        public GetEventListState(ITelegramBotClient bot) : base(bot)
        {
            NextState = "GetBeginDate";
            BotMessage = "Enter interval ([min events start date] - [max events start date]):";
        }
    }
}