using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Entities;
using System.Threading.Tasks;
using Telegram.Bot;
using System;
using System.Linq;
using System.Collections.Generic;

namespace OneSchedule.Domain
{
    public class NotificationSender : INotificationSender
    {

        private const int TwentySeconds = 20;
        private readonly ITelegramBotClient _bot;
        private readonly IRepository<EventEntity> _repository;

        public NotificationSender(ITelegramBotClient bot, IRepository<EventEntity> eventRepository)
        {
            _bot = bot;
            _repository = eventRepository;
        }

        public async Task SendNotification()
        {
            var actualTimeMinus30seconds = DateTime.Now.AddSeconds(-30);
            var actualTimePlus30seconds = DateTime.Now.AddSeconds(30);

            List<EventEntity> events = await _repository.FindAsync(e => true);

            foreach (var item in events)
            {
                foreach (var n in item.Notifications)
                {
                    if (n.Date <= actualTimePlus30seconds && n.Date >= actualTimeMinus30seconds)
                    {
                        await _bot.SendTextMessageAsync(item.ChatId, $"Event {item.Title} will begin at {item.StartDate}");
                    }
                }
            }
        }
    }
}