namespace Infrastructure.Interfaces
{
    public interface IScheduleDatabaseSettings
    {
        public string UserCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
