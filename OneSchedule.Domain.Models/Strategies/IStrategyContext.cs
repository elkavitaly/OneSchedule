using System.Threading.Tasks;

namespace OneSchedule.Domain.Models.Strategies
{
    public interface IStrategyContext
    {
        Task ExecuteAsync(DtoDomain dto);
    }
}
