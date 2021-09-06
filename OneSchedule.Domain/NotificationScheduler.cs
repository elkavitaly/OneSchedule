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

        public NotificationScheduler(ITelegramBotClient bot)
        {
            _bot = bot;

        }

        public async void ScheduleNotifications(EventEntity eventEntity)
        {
            IScheduler scheduler = SchedulerRepository.Instance.Lookup("Quartz ASP.NET�Core Sample Scheduler").Result;

            foreach (var item in eventEntity.Notifications)
            {
                await scheduler.ScheduleJob(() => _bot.SendTextMessageAsync(eventEntity.ChatId, $"Event {eventEntity.Title} will begin at {eventEntity.StartDate}"),
                            builder => builder.StartAt(item.Date));
            }
        }
    }
}
