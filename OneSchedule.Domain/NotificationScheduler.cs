using Microsoft.Extensions.Configuration;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Entities;
using Quartz;
using Quartz.Impl;
using Quartz.Lambda;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain
{
    public class NotificationScheduler : INotificationScheduler
    {
        private readonly ITelegramBotClient _bot;
        private readonly IConfiguration _configuration;

        public NotificationScheduler(ITelegramBotClient bot, IConfiguration configuration)
        {
            _bot = bot;
            _configuration = configuration;
        }

        public async Task ScheduleNotifications(EventEntity eventEntity)
        {
            IScheduler scheduler = await SchedulerRepository.Instance.Lookup(_configuration.GetSection("Quartz").GetSection("quartz.scheduler.instanceName").Value);

            List<Task> tasks = new List<Task>(eventEntity.Notifications.Count);

            foreach (var item in eventEntity.Notifications)
            {
                tasks.Add( scheduler.ScheduleJob(() => _bot.SendTextMessageAsync(eventEntity.ChatId, $"Event {eventEntity.Title} will begin at {eventEntity.StartDate}"),
                            builder => builder.StartAt(item.Date)));
            }
            await Task.WhenAll(tasks.ToArray());
        }
    }
}
