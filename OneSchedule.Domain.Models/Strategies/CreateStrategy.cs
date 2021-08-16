using OneSchedule.Attributes;
using System;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Models.Strategies
{
    [StrategyName("create")]
    public class CreateStrategy : IStrategy
    {
        public Task Execute(DtoDomain dto)
        {
            throw new NotImplementedException();
        }
    }
}
