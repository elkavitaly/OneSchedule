using Infrastructure.Interfaces;

namespace BotWebApi
{
    public class ScheduleDatabaseSettings : IScheduleDatabaseSettings
    {
        public string UserCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
