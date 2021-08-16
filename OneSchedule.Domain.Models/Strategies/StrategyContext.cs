using OneSchedule.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Models.Strategies
{
    public class StrategyContext:IStrategyContext
    {
        private readonly Dictionary<string, IStrategy> _strategies;

        public StrategyContext(IEnumerable<IStrategy> strategies)
        {
            _strategies = strategies.ToDictionary(s => StrategyNameReader.GetStrategy(s.GetType()));
        }

        public async Task Execute(string command, EventDomain eventDomain)
        {
            if (_strategies.ContainsKey(command))
            {
                await _strategies[command].Execute(eventDomain);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
