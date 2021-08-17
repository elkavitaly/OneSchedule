using OneSchedule.Attributes;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskNotifications")]
    public class AskNotificationsState : BaseAskState
    {
        public AskNotificationsState(ITelegramBotClient bot) : base(bot)
        {
            NextState = "GetNotifications";
            BotMessage = "Enter event notifications([date1] [date2]...):";
        }
    }
}