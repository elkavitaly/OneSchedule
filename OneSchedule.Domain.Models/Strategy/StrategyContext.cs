using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Models.Strategy
{
    public class StrategyContext
    {
        private readonly Dictionary<string, IStrategy> _strategies;

        public StrategyContext(IEnumerable<IStrategy> strategies)
        {
            _strategies = new Dictionary<string, IStrategy>();
            foreach (var strategy in strategies)
            {
                var key = strategy.GetType().Name.Replace("Strategy", "");
                _strategies.Add(key, strategy);
            }
        }

        public async Task Execute(string command, EventDomain eventDomain)
        {
            if (_strategies.ContainsKey(command))
            {
                await _strategies[command].Execute(eventDomain);
            }
            else
            {
                
            }
        }
    }
}
