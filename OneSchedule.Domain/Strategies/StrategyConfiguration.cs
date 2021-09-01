using Microsoft.Extensions.DependencyInjection;
using OneSchedule.Domain.Abstractions.Strategies;

namespace OneSchedule.Domain.Strategies
{
    public static class StrategyConfiguration
    {
        public static IServiceCollection ConfigureStrategy(this IServiceCollection services)
        {
            services.AddSingleton<IStrategy, CreateStrategy>();
            services.AddSingleton<IStrategy, DataStrategy>();
            services.AddSingleton<IStrategy, DeleteStrategy>();
            services.AddSingleton<IStrategy, EditStrategy>();
            services.AddSingleton<IStrategy, EventStrategy>();
            services.AddSingleton<IStrategy, GetStrategy>();
            services.AddSingleton<IStrategy, MenuStrategy>();
            services.AddSingleton<IStrategy, SaveStrategy>();
            return services;
        }
    }
}
