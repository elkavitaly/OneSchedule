using Microsoft.Extensions.DependencyInjection;
using OneSchedule.Domain.Abstractions.Strategies;

namespace OneSchedule.Domain.Strategies
{
    public static class StrategyConfiguration
    {
        public static IServiceCollection ConfigureStrategy(this IServiceCollection services)
        {
            services.AddSingleton<IStrategy, CreateStrategy>();
            services.AddSingleton<IStrategy, EditStrategy>();
            services.AddSingleton<IStrategy, FindStrategy>();
            services.AddSingleton<IStrategy, RemoveStrategy>();
            services.AddSingleton<IStrategyContext, StrategyContext>();
            return services;
        }
    }
}
