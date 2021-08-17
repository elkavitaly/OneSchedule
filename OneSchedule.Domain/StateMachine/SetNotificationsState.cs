using OneSchedule.Attributes;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain.StateMachine
{
    [StateName("SetNotifications")]
    public class SetNotificationsState : IState
    {
        private const string SetNotifications = "SetNotifications";
        private const string BotMessage = "Event added";
        private readonly IRepository<EventEntity> _eventRepository;
        private readonly ITelegramBotClient _bot;
        IRepository<ContextEntity> _contextRepository;

        public SetNotificationsState(ITelegramBotClient bot, 
            IRepository<EventEntity> eventRepository,
            IRepository<ContextEntity> contextRepository)
        {
            _bot = bot;
            _eventRepository = eventRepository;
            _contextRepository = contextRepository;
        }

        public async Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain)
        {
            var dates = dtoDomain.MessageText.Split(" ");

            foreach (var date in dates)
            {
                var notification = new NotificationEntity() { Date = DateTime.Parse(date) };
                stateContext.EventEntity.Notifications.Add(notification);
            }

            await _eventRepository.UpdateAsync(stateContext.EventEntity);
            await _contextRepository.DeleteAsync(GetContextEntity(dtoDomain).Result.Id);
            await _bot.SendTextMessageAsync(dtoDomain.ChatId, BotMessage);
        }

        private async Task<ContextEntity> GetContextEntity(DtoDomain dtoDomain)
        {
            return await _contextRepository.FindFirstAsync(c => c.Event.ChatId == dtoDomain.ChatId
                && c.Event.OwnerId == dtoDomain.UserId);
        }
    }
}
