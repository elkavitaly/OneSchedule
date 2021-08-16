using OneSchedule.Attributes;

namespace OneSchedule.Entities
{
    [CollectionName("Entities")]
    public class ContextEntity : BaseEntityModel
    {
        public EventEntity Event { get; set; }

        public string NextState { get; set; }
    }
}
