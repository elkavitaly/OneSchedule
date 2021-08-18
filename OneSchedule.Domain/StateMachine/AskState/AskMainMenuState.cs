using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskMainMenu")]
    public class AskMainMenuState : BaseAskState
    {
        public AskMainMenuState(ITelegramBotClient bot) : base(bot)
        {
            NextState = "GetMainMenu";
            BotMessage = "Select option:";
        }

        public override async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            //await base.HandleAsync(stateContext, dtoDomain);
            var keys = new List<KeyboardButton>
            {
                new KeyboardButton {Text = "/create"},
                new KeyboardButton {Text = "/get"},
            };

            var markup = new ReplyKeyboardMarkup(keys);
            await Bot.SendTextMessageAsync(dtoDomain.ChatId, "Select option:", replyMarkup: markup);
        }
    }
}