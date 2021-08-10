using OneSchedule.Helpers;
using System;

namespace OneSchedule.Entities
{
    [CollectionName("Notifications")]
    public class NotificationEntity : BaseEntityModel
    {
        public DateTime Date { get; set; }
    }
}
