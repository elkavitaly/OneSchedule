using OneSchedule.Attributes;
using System;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Models.Strategies
{
    [StrategyName("edit")]
    public class EditStrategy : IStrategy
    {
        public Task ExecuteAsync(DtoDomain dto)
        {
            throw new NotImplementedException();
        }
    }
}
