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
            services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));
            services.AddSingleton<IMongoClient, MongoClient>();
            services.AddSingleton<IRepository<EventEntity>, MongodbRepository<EventEntity>>();
            services.AddSingleton<IRepository<UserEntity>, MongodbRepository<UserEntity>>();
            return services;
        }
    }
}
