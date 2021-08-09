namespace OneSchedule.Settings
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string UserCollectionName { get; set; }

        public string EventCollectionName { get; set; }

        public string NotificationCollectionName { get; set; }
    }
}
