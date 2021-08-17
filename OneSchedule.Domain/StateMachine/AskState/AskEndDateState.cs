using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskEndDate")]
    public class AskEndDateState : BaseAskState
    {
        public AskEndDateState(ITelegramBotClient bot):base(bot)
        {
            NextState = "GetEndDate";
            BotMessage = "Enter event end date and time:";
        }
    }
}