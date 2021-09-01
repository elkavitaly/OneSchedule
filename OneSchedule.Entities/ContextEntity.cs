using OneSchedule.Attributes;
using System;

namespace OneSchedule.Entities
{
    [CollectionName("Entities")]
    public class ContextEntity : BaseEntityModel
    {
        public EventEntity Event { get; set; }

        public string LastState { get; set; }

        public DateTime MinStartDate { get; set; }

        public DateTime MaxStartDate { get; set; }
    }
}
