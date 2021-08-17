using OneSchedule.Entities;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Abstractions.StateMachine
{
    public interface IStateContext
    {
        public EventEntity EventEntity { get; set; }

        public bool IsContextCompleted { get; }

        public void SetState(string state);

        public Task DeleteContextAsync(string id);
    }
}
