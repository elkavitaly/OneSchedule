using OneSchedule.Attributes;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace OneSchedule.Domain.StateMachine.AskState
{
    [StateName("AskEventMenu")]
    public class AskEventMenuState : BaseAskState
    {
        private readonly IRepository<EventEntity> _eventRepository;
        public AskEventMenuState(ITelegramBotClient bot, IRepository<EventEntity> eventRepository) : base(bot)
        {
            NextState = "GetEventMenu";
            BotMessage = "Select option:";
            _eventRepository = eventRepository;
        }

        public override async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            await base.HandleAsync(stateContext, dtoDomain);
            var keys = new List<KeyboardButton>();

            var events = await _eventRepository.FindAsync(e =>
                e.StartDate >= stateContext.ContextEntity.MinStartDate &&
                e.StartDate <= stateContext.ContextEntity.MaxStartDate);

            foreach (var eventEntity in events)
            {
                keys.Add(new KeyboardButton { Text = $"{eventEntity.Title} {eventEntity.Id}" });
            }

            if (string.IsNullOrWhiteSpace(stateContext.ContextEntity.Event.Id))
            {
                keys.Add(new KeyboardButton { Text = $"/menu" });
            }

            var markup = new ReplyKeyboardMarkup(keys);

            await Bot.SendTextMessageAsync(dtoDomain.ChatId, string.Empty, replyMarkup: markup);
        }
    }
}