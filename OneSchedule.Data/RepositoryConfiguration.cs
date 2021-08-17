using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using OneSchedule.Data.Abstractions;
using OneSchedule.Settings;

namespace OneSchedule.Data
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection ConfigureRepository(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseSettings = configuration.GetSection(nameof(DatabaseSettings));
            var databaseSettingsValue = databaseSettings.Get<DatabaseSettings>();
            services.Configure<DatabaseSettings>(databaseSettings);
            services.AddSingleton<IMongoClient>(new MongoClient(databaseSettingsValue.ConnectionString));
            services.AddSingleton(typeof(IRepository<>), typeof(MongodbRepository<>));
            return services;
        }
    }
}
