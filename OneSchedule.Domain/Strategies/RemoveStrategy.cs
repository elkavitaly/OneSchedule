using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.Strategies;
using OneSchedule.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Strategies
{
    [StrategyName("remove")]
    public class RemoveStrategy : IStrategy
    {
        public Task ExecuteAsync(DtoDomain dto)
        {
            throw new NotImplementedException();
        }
    }
}
