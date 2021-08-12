using OneSchedule.Attributes;
using System;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Models.Strategy
{
    [StrategyName("create")]
    public class CreateStrategy: IStrategy
    {
        public Task Execute(EventDomain eventDomain)
        {
            throw new NotImplementedException();
        }
    }
}
