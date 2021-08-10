using OneSchedule.Helpers;
using System;

namespace OneSchedule.Entities
{
    [CollectionName("Events")]
    public class NotificationEntity : BaseEntityModel
    {
        public DateTime Date { get; set; }
    }
}
