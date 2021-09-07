using OneSchedule.Entities;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Abstractions
{
    public interface INotificationScheduler
    {
        Task ScheduleNotifications(EventEntity eventEntity);
    }
}
