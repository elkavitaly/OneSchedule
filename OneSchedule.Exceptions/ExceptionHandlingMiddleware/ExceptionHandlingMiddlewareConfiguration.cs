using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OneSchedule.Settings;
using Telegram.Bot;

namespace OneSchedule.Exceptions.ExceptionHandlingMiddleware
{
    public static class ExceptionHandlingMiddlewareConfiguration
    {
        public static IServiceCollection ConfigureExceptionHandlingMiddleware(this IServiceCollection services, IConfiguration configuration)
        {
            var telegramSettings = configuration.GetSection(nameof(TelegramSettings));
            var telegramSettingsValue = telegramSettings.Get<TelegramSettings>();
            services.AddSingleton<ITelegramBotClient>(new TelegramBotClient(telegramSettingsValue.ApiKey));
            return services;
        }
    }
}
