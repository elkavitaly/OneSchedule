using OneSchedule.Domain.Models;
using System.Threading.Tasks;


namespace OneSchedule.Domain.Abstractions.StateMachine
{
    public interface IState
    {
        public Task HandleAsync(IStateContext stateContext, DtoDomain dtoDomain);
    }
}
