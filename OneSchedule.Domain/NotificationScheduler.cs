using OneSchedule.Domain.Abstractions;
using OneSchedule.Entities;
using Quartz;
using Quartz.Impl;
using Quartz.Lambda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain
{
    public class NotificationScheduler : INotificationScheduler
    {
        private readonly ITelegramBotClient _bot;
        IScheduler _scheduler;

        public NotificationScheduler(ITelegramBotClient bot, IScheduler scheduler)
        {
            _bot = bot;
            _scheduler = scheduler;
        }

        public async void ScheduleNotifications(EventEntity eventEntity)
        {
            var tasks = new List<Task>();
            foreach (var item in eventEntity.Notifications)
            {
                tasks.Add(_scheduler.ScheduleJob(() => _bot.SendTextMessageAsync(eventEntity.ChatId, $"Event {eventEntity.Title} will begin at {eventEntity.StartDate}"),
                            builder => builder.StartAt(item.Date)));             
            }

            tasks.ForEach(t => t.Start());
            await Task.WhenAll(tasks);
        }
    }
}
