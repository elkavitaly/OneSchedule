using OneSchedule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Abstractions
{
    public interface INotificationScheduler
    {
        Task ScheduleNotifications(EventEntity eventEntity);
    }
}
