using OneSchedule.Domain.Abstractions.Strategies;
using OneSchedule.Domain.Models;
using OneSchedule.Exceptions.CustomExceptions;
using OneSchedule.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Strategies
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
            Console.WriteLine("____________");
            Console.WriteLine(dto.MessageText);
            Console.WriteLine("____________");

            var strategy = _strategies
                .FirstOrDefault(s => dto.MessageText != null && dto.MessageText.Contains(s.Key));

            if (!strategy.Equals(default(KeyValuePair<string, IStrategy>)))
            {
                await strategy.Value.ExecuteAsync(dto);
            }
            else
            {
                throw new BotAppInternalException("Invalid command");
            }
        }
    }
}
