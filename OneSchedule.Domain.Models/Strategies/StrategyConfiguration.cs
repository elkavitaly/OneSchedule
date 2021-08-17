using Microsoft.Extensions.DependencyInjection;

namespace OneSchedule.Domain.Models.Strategies
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
