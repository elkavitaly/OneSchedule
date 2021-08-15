using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OneSchedule.Data.Abstractions;
using OneSchedule.Settings;

namespace OneSchedule.Mongodb
{
    public static class RepositoryConfiguration
    {
        public static void AddScheduleDatabaseSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));

            services.AddSingleton<IDatabaseSettings>(options => options.GetService<IOptions<DatabaseSettings>>().Value);
        }

        public static void AddMongoClientAndDatabase(this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient>(options =>
            {
                var something = options.GetService<IDatabaseSettings>();
                return new MongoClient(options.GetService<IDatabaseSettings>().ConnectionString);
            });

            services.AddScoped(options => options.GetService<IMongoClient>().StartSession());

            services.AddScoped<IMongoDatabase>(options =>
               (MongoDatabaseBase)options.GetService<IMongoClient>().GetDatabase(options.GetService<IDatabaseSettings>().DatabaseName));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(MongodbRepository<>));
        }
    }
}
