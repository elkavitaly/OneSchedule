using OneSchedule.Attributes;
using System;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Models.Strategy
{
    [StrategyName("find")]
    public class FindStrategy : IStrategy
    {
        public Task Execute(EventDomain eventDomain)
        {
            throw new NotImplementedException();
        }
    }
}
