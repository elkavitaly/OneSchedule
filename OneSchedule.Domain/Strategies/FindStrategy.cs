using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.Strategies;
using OneSchedule.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Strategies
{
    [StrategyName("find")]
    public class FindStrategy : IStrategy
    {
        public Task ExecuteAsync(DtoDomain dto)
        {
            throw new NotImplementedException();
        }
    }
}
