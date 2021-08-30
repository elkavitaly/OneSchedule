using System.Threading.Tasks;
using System.Timers;

namespace OneSchedule.Domain.Abstractions
{
    public interface INotificationSender
    {
        public async Task SendNotification() { }
    }
}
