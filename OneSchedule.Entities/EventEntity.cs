using OneSchedule.Attributes;
using System;
using System.Collections.Generic;

namespace OneSchedule.Entities
{
    [CollectionName("Events")]
    public class EventEntity : BaseEntityModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime LastUpdate { get; set; }

        public DateTime CreatedDate { get; set; }

        public string OwnerId { get; set; }

        public string ChatId { get; set; }

        public List<NotificationEntity> Notifications { get; set; }
    }
}
