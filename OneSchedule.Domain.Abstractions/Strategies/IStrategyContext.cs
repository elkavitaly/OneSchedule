using OneSchedule.Domain.Models;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Abstractions.Strategies
{
    public interface IStrategyContext
    {
        Task ExecuteAsync(DtoDomain dto);
    }
}
