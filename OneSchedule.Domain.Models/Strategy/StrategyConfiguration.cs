using Microsoft.Extensions.DependencyInjection;

namespace OneSchedule.Domain.Models.Strategy
{
    public static class StrategyConfiguration
    {
        public static IServiceCollection ConfigureStrategy(this IServiceCollection services)
        {
            services.AddSingleton<IStrategy, CreateStrategy>();
            services.AddSingleton<IStrategy, EditStrategy>();

            services.AddSingleton<StrategyContext>();
            return services;
        }
    }
}
