using OneSchedule.Domain.Abstractions;
using Quartz;
using System.Threading.Tasks;

namespace OneSchedule.Domain
{
    public class NotificationSenderJob : IJob
    {
        private readonly INotificationSender _notificationSender;

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