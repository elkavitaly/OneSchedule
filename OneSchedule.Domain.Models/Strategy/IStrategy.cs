using System.Threading.Tasks;

namespace OneSchedule.Domain.Models.Strategy
{
    public interface IStrategy
    {
        Task Execute(EventDomain eventDomain);
    }
}
