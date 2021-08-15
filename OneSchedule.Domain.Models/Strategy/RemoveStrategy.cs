using OneSchedule.Attributes;
using System;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Models.Strategy
{
    [StrategyName("remove")]
    public class RemoveStrategy : IStrategy
    {
        public Task Execute(EventDomain eventDomain)
        {
            throw new NotImplementedException();
        }
    }
}
