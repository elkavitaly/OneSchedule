using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskEventMenu")]
    public class AskEventMenuState : BaseAskState
    {
        public AskEventMenuState(ITelegramBotClient bot) : base(bot)
        {
            BotMessage = "Select option:";
        }

        public override async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {

            var inlineButtons1 = new List<KeyboardButton>
            {
                new KeyboardButton(){Text = $"[event] Title edit" },
                new KeyboardButton(){Text = $"[event] Description edit" }
            };

            var inlineButtons2 = new List<KeyboardButton>
            {
                new KeyboardButton(){Text = $"[event] Start date edit" },
                new KeyboardButton(){Text = $"[event] End date edit" }
            };

            var inlineButtons3 = new List<KeyboardButton>
            {
                new KeyboardButton(){Text = $"[event] Notifications edit" }
            };

            var inlineButtons4 = new List<KeyboardButton>();
            if (!string.IsNullOrWhiteSpace(stateContext.ContextEntity.Event.Id))
            {
                inlineButtons4.Add(new KeyboardButton() {Text = $"[delete] Event"});
            }

            var inlineButtons5 = new List<KeyboardButton>
            {
                new KeyboardButton(){Text = $"[save] Event" }
            };

            var inlineButtons6 = new List<KeyboardButton>
            {
                new KeyboardButton(){Text = $"[menu]"}
            };

            var buttons = new List<IList<KeyboardButton>>
            {
                inlineButtons1,
                inlineButtons2,
                inlineButtons3, 
                inlineButtons4, 
                inlineButtons5,
                inlineButtons6
            };

            var keyboard = new ReplyKeyboardMarkup(buttons);

            await Bot.SendTextMessageAsync(dtoDomain.ChatId, BotMessage, replyMarkup: keyboard);
        }
    }
}