using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using OneSchedule.Settings;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule
{
    public class SetWebHookService : IHostedService
    {
        private readonly IOptions<WebHookSettings> _webHookOptions;
        private readonly ITelegramBotClient _bot;

        public SetWebHookService(IOptions<WebHookSettings> webHookOptions, ITelegramBotClient bot)
        {
            _webHookOptions = webHookOptions;
            _bot = bot;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(_webHookOptions.Value.Uri) && _bot != null)
            {
                if (_webHookOptions.Value.IsEnabled)
                {
                    await _bot.SetWebhookAsync(_webHookOptions.Value.Uri);
                }
                else
                {
                    await _bot.DeleteWebhookAsync();
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
