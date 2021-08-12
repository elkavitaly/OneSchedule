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
            await _strategy.Execute(message);
        }
    }
}
