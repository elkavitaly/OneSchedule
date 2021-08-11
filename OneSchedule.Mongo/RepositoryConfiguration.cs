using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using OneSchedule.Data.Abstractions;
using OneSchedule.Entities;
using OneSchedule.Settings;

namespace OneSchedule.Mongodb   
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection ConfigureRepository(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseSettings = configuration.GetSection(nameof(DatabaseSettings));
            var databaseSettingsValue = databaseSettings.Get<DatabaseSettings>();
            services.Configure<DatabaseSettings>(databaseSettings);
            services.AddSingleton<IMongoClient>(new MongoClient(databaseSettingsValue.ConnectionString));
            services.AddSingleton<IRepository<EventEntity>, MongodbRepository<EventEntity>>();
            services.AddSingleton<IRepository<UserEntity>, MongodbRepository<UserEntity>>();
            return services;
        }
    }
}
    