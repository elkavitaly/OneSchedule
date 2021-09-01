using OneSchedule.Domain.Abstractions;
using System;
using System.Threading.Tasks;

namespace OneSchedule.Services
{
    public class NotificationSender : INotificationSender
    {

        Task INotificationSender.SendNotification()
        {
            throw new NotImplementedException();
        }
    }
}
