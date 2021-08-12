using OneSchedule.Attributes;
using System;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Models.Strategy
{
    [StrategyName("edit")]
    public class EditStrategy : IStrategy
    {
        public Task Execute(EventDomain eventDomain)
        {
            throw new NotImplementedException();
        }
    }
}
