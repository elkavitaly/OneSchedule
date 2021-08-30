using OneSchedule.Domain.Abstractions;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSchedule.Domain
{
    public class NotificationSenderJob : IJob
    {
        private INotificationSender _notificationSender;

        public NotificationSenderJob(INotificationSender notificationSender)
        {
            _notificationSender = notificationSender;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _notificationSender.SendNotification();
        }
    }
}
