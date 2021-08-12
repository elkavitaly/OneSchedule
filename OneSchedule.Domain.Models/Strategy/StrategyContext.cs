using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace OneSchedule.Domain.Models.Strategy
{
    public class StrategyContext
    {
        private IStrategy _strategy;

        public StrategyContext()
        {
        }

        public StrategyContext(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public async Task Execute(Message message)
        {
            switch (message.Text)
            {
                case "1":
                    _strategy = new CreateStrategy();
                    await _strategy.Execute(message);
                    break;
                case "2":
                    break;
                case "3":
                    break;
                default:
                    break;
            }
        }
    }
}
