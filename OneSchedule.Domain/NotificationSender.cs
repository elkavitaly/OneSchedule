using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Entities;
using System.Threading.Tasks;
using Telegram.Bot;
using System;

namespace OneSchedule.Domain
{
    public class NotificationSender : INotificationSender
    {
        private const int DeltaTime = 30;
        private readonly ITelegramBotClient _bot;
        private readonly IRepository<EventEntity> _repository;

        public NotificationSender(ITelegramBotClient bot, IRepository<EventEntity> eventRepository)
        {
            _bot = bot;
            _repository = eventRepository;
        }

        public async Task SendNotification()
        {
            var actualTimeMinusDeltaTime = DateTime.Now.AddSeconds(-DeltaTime);
            var actualTimePlusDeltaTime = DateTime.Now.AddSeconds(DeltaTime);

            var events = await _repository.FindAsync(e => true);

            foreach (var item in events)
            {
                foreach (var n in item.Notifications)
                {
                    if (n.Date <= actualTimePlusDeltaTime && n.Date >= actualTimeMinusDeltaTime)
                    {
                        await _bot.SendTextMessageAsync(item.ChatId, $"Event {item.Title} will begin at {item.StartDate}");
                    }
                }
            }
        }
    }
}