namespace OneSchedule.Abstraction
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }

        string UserCollectionName { get; set; }

        string EventCollectionName { get; set; }

        string NotificationCollectionName { get; set; }
    }
}
