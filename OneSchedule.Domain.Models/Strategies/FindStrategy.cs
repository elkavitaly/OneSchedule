using OneSchedule.Attributes;
using System;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Models.Strategies
{
    [StrategyName("find")]
    public class FindStrategy : IStrategy
    {
        public Task Execute(DtoDomain dto)
        {
            throw new NotImplementedException();
        }
    }
}
