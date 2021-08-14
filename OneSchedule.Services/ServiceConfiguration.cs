using Microsoft.Extensions.DependencyInjection;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.Models;

namespace OneSchedule.Services
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureService(this IServiceCollection services)
        {
            services.AddScoped<IService<UserDomain>, UserService>();
            services.AddScoped<IService<EventDomain>, EventService>();
            services.AddScoped<IService<NotificationDomain>, NotificationService>();
            return services;
        }
    }
}
