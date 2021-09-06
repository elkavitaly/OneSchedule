using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using OneSchedule.Settings;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Domain
{
    public class SetWebHookService : IHostedService
    {
        private readonly IOptions<TelegramSettings> _telegramOptions;
        private readonly IOptions<WebHookSettings> _webHookOptions;

        public SetWebHookService(IOptions<TelegramSettings> telegramOptions,
            IOptions<WebHookSettings> webHookOptions)
        {
            _telegramOptions = telegramOptions;
            _webHookOptions = webHookOptions;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(_webHookOptions.Value.Uri)
                && !string.IsNullOrEmpty(_telegramOptions.Value.ApiKey))
            {
                var bot = new TelegramBotClient(_telegramOptions.Value.ApiKey);

                if (_webHookOptions.Value.IsUsed)
                {
                    await bot.SetWebhookAsync(_webHookOptions.Value.Uri);
                }
                else
                {
                    await bot.DeleteWebhookAsync();
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
