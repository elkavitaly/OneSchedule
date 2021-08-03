namespace OneScheduleEntities
{
    public class Message
    {
        public int MessageId { get; set; }
        public User From { get; set; }
        public Chat SenderChat { get; set; }
    }
}
