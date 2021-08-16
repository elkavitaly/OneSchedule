using OneSchedule.Attributes;

namespace OneSchedule.Entities
{
    [CollectionName("Entities")]
    public class ContextEntity : BaseEntityModel
    {
        public string ChatId { get; set; }

        public string UserId { get; set; }

        public string EventId { get; set; }

        public string LastState { get; set; }
    }
}
