namespace OneScheduleTelegram
{
    using System.Collections.Generic;
    using System.Linq;
    using Telegram.Bot;
    using Telegram.Bot.Types;

    public class TelegramRepository
    {
        private const string BotTokenC = "1774119603:AAFCWMV12zS0SLBx4kC3A-suLJ511wP4oOo";
        private readonly TelegramBotClient _botClient;

        public TelegramRepository()
        {
            _botClient = new TelegramBotClient(BotTokenC);
        }

        public List<Update> GetUpdates(int offset)
        {
            return _botClient.GetUpdatesAsync(offset).Result.ToList();
        }
    }
}
