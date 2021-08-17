using OneSchedule.Attributes;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskDescription")]
    public class AskDescriptionState : BaseAskState
    {
        public AskDescriptionState(ITelegramBotClient bot) : base(bot)
        {
            NextState = "GetDescription";
            BotMessage = "Enter event description";
        }
    }
}
