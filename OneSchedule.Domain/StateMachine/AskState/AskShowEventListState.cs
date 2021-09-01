using OneSchedule.Attributes;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskShowEventList")]
    public class AskShowEventListState : BaseAskState
    {
        private readonly IRepository<EventEntity> _eventRepository;
        public AskShowEventListState(ITelegramBotClient bot, IRepository<EventEntity> eventRepository) : base(bot)
        {
            BotMessage = "Select option:";
            _eventRepository = eventRepository;
        }

        public override async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            var events = await _eventRepository.FindAsync(e =>
               e.StartDate >= stateContext.MinStartDate && e.StartDate <= stateContext.MaxStartDate);

            var keys = events
                .Take(20)
                .Select(eventEntity => $"[edit] {eventEntity.Title}")
                .ToList();

            var buttons = new List<IList<KeyboardButton>>();
            var counter = 0;
            for (var i = 0; i < 5; i++)
            {
                if (counter < keys.Count)
                {
                    buttons.Add(new List<KeyboardButton>());
                    for (var j = 0; j < 4; j++)
                    {
                        if (counter < keys.Count)
                        {
                            buttons[i].Add(new KeyboardButton() {Text = keys[counter]});
                            counter++;
                        }
                    }
                }
            }

            buttons.Add(new List<KeyboardButton>() { new KeyboardButton() { Text = "[menu]" } });

            var markup = new ReplyKeyboardMarkup(buttons);

            await Bot.SendTextMessageAsync(dtoDomain.ChatId, "Select option:", replyMarkup: markup);
        }
    }
}