using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Abstractions.Strategies
{
    public interface IStrategy
    {
        Task ExecuteAsync(IStateContext context, DtoDomain dto);
    }
}
