using System.Threading.Tasks;

namespace OneSchedule.Domain.Models.Strategies
{
    public interface IStrategyContext
    {
        Task Execute(string command, EventDomain eventDomain);
    }
}
    