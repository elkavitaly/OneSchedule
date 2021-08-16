namespace OneSchedule.Domain.Models
{
    public class DtoDomain : BaseDomainModel
    {
        public string UserId { get; set; }

        public string ChatId { get; set; }

        public string MessageText { get; set; }
    }
}
