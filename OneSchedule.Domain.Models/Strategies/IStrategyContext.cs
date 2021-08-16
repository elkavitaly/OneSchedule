using System.Threading.Tasks;

namespace OneSchedule.Domain.Models.Strategies
{
    public interface IStrategyContext
    {
        Task Execute(DtoDomain dto);
    }
}
    