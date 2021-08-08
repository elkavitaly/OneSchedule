namespace OneSchedule.Entities
{
    using Abstraction;

    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string UserCollectionName { get; set; }

        public string EventCollectionName { get; set; }

        public string NotificationCollectionName { get; set; }
    }
}
