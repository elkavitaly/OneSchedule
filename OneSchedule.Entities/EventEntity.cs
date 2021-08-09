using System;
using System.Collections.Generic;

namespace OneSchedule.Entities
{
    public class EventEntity : BaseEntityModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime LastUpdate { get; set; }

        public DateTime CreatedDate { get; set; }

        public string OwnerId { get; set; }

        public int ChatId { get; set; }

        public List<NotificationEntity> Notifications { get; set; }
    }
}
