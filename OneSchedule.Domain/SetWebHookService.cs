using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using OneSchedule.Settings;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain
{
    public class SetWebHookService: IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies()
                .Single(o => o.EntryPoint != null);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddUserSecrets(assembly)
                .Build();

            var telegramSettings = new TelegramSettings()
            {
                ApiKey = configuration.GetSection("TelegramSettings").GetSection("ApiKey").Value
            };

            var webHookSettings = new WebHookSettings()
            {
                IsUsed = configuration.GetSection("WebHook").GetSection("IsUsed").Get<bool>(),
                Uri = configuration.GetSection("WebHook").GetSection("Uri").Value
            };

            var bot = new TelegramBotClient(telegramSettings.ApiKey);

            if (webHookSettings.IsUsed)
            {
                await bot.SetWebhookAsync(webHookSettings.Uri);
            }
            else
            {
                await bot.SetWebhookAsync(string.Empty);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
