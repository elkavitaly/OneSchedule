using OneSchedule.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Models.Strategies
{
    public class StrategyContext : IStrategyContext
    {
        private readonly Dictionary<string, IStrategy> _strategies;

        public StrategyContext(IEnumerable<IStrategy> strategies)
        {
            _strategies = strategies.ToDictionary(s => StrategyNameReader.GetStrategyName(s.GetType()));
        }

        public async Task ExecuteAsync(DtoDomain dto)
        {
            var strategy = _strategies.FirstOrDefault(s => dto.MessageText.Contains(s.Key));
            if (!strategy.Equals(default(KeyValuePair<string, IStrategy>)))
            {
                await strategy.Value.ExecuteAsync(dto);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
