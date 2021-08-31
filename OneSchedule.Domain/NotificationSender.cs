using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Entities;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain
{
    public class NotificationSender:INotificationSender
    {
        private const int TenSeconds = 10;

        public NotificationSender(ITelegramBotClient bot, IRepository<EventEntity> eventRepository)
        {

        }
        public Task SendNotification()
        {
            return Task.CompletedTask;
        }
    }
}
