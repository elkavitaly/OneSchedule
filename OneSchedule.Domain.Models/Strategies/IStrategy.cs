using System.Threading.Tasks;

namespace OneSchedule.Domain.Models.Strategies
{
    public interface IStrategy
    {
        Task Execute(EventDomain eventDomain);
    }
}
