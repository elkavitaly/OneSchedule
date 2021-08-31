using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Entities;
using Quartz;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain
{
    public class NotificationSender:INotificationSender
    {
        private const int TenSeconds = 10;
        private readonly ITelegramBotClient _bot;
        private readonly IRepository<EventEntity> _repository;

        public NotificationSender(ITelegramBotClient bot, IRepository<EventEntity> eventRepository)
        {

        }
        public async Task SendNotification()
        {

        }
    }
}
