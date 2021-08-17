using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskDescription")]
    public class AskDescriptionState : BaseAskState
    {
        public AskDescriptionState(ITelegramBotClient bot):base(bot)
        {
            NextState = "GetDescription";
            BotMessage = "Enter event description";
        }
    }
}
