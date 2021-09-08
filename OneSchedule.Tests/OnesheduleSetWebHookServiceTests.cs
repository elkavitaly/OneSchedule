using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using OneSchedule.Settings;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Tests
{
    public class OnesheduleSetWebHookServiceTests
    {
        private readonly Mock<ITelegramBotClient> _botMoq;

        public OnesheduleSetWebHookServiceTests()
        {
            _botMoq = new Mock<ITelegramBotClient>();
        }

        [Test]
        public async Task StopAsync_ReturnStatus_RanToCompletion()
        {
            var token = new CancellationToken(false);
            var hostedServiceMock = new Mock<IHostedService>();

            await hostedServiceMock.Object.StopAsync(token);

            hostedServiceMock.Verify(o => o.StopAsync(token), Times.Once);
        }

        [Test]
        public async Task StartAsync_WebHookIsEnabled()
        {
            var token = new CancellationToken(false);
            var uri = "uri";
            var optionsMoq = new Mock<IOptions<WebHookSettings>>();
            optionsMoq.Setup(o => o.Value).Returns(new WebHookSettings() { IsEnabled = true, Uri = uri });
            var hostedServiceMock = new SetWebHookService(optionsMoq.Object, _botMoq.Object);

            await hostedServiceMock.StartAsync(token);

            _botMoq.Verify(o => o.SetWebhookAsync(uri, null, null, 0, null, false, token), Times.Once);
        }

        [Test]
        public async Task StartAsync_WebHookIsNotEnabled()
        {
            var token = new CancellationToken(false);
            var uri = "uri";
            var optionsMoq = new Mock<IOptions<WebHookSettings>>();
            optionsMoq.Setup(o => o.Value).Returns(new WebHookSettings() { IsEnabled = false, Uri = uri });
            var hostedServiceMock = new SetWebHookService(optionsMoq.Object, _botMoq.Object);

            await hostedServiceMock.StartAsync(token);

            _botMoq.Verify(o => o.DeleteWebhookAsync(false, token), Times.Once);
        }

        [Test]
        public async Task StartAsync_UriIsEmpty()
        {
            var token = new CancellationToken(false);
            var uri = "";
            var optionsMoq = new Mock<IOptions<WebHookSettings>>();
            optionsMoq.Setup(o => o.Value).Returns(new WebHookSettings() { IsEnabled = false, Uri = uri });
            var hostedServiceMock = new SetWebHookService(optionsMoq.Object, _botMoq.Object);

            await hostedServiceMock.StartAsync(token);

            _botMoq.Verify(o => o.DeleteWebhookAsync(false, token), Times.Never);
        }
    }
}