using Microsoft.Extensions.DependencyInjection;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.Models;

namespace OneSchedule.Services
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureService(this IServiceCollection services)
        {
            services.AddSingleton<IService<UserDomain>, UserService>();
            services.AddSingleton<IService<EventDomain>, EventService>();
            return services;
        }
    }
}
