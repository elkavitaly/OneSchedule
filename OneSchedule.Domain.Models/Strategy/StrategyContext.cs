using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Models.Strategy
{
    public class StrategyContext
    {
        private readonly Dictionary<string, IStrategy> _strategies;

        public StrategyContext(Dictionary<string, IStrategy> strategies)
        {
            _strategies = strategies;
        }

        public async Task Execute(string command, EventDomain eventDomain)
        {
            await _strategies[command].Execute(eventDomain);
        }
    }
}
