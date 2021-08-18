using OneSchedule.Attributes;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Entities;
using System.Collections.Generic;

namespace OneSchedule.Domain.StateMachine
{
    [StateContextName("Create")]
    public class CreateStateContext : BaseStateContext
    {
        public CreateStateContext(IEnumerable<IState> states, IRepository<ContextEntity> contextRepository) : base(states, contextRepository)
        {
            NextState = "AskEventMenu";
        }
    }
}