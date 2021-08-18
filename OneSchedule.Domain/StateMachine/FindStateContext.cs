using OneSchedule.Attributes;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Entities;
using System;
using System.Collections.Generic;

namespace OneSchedule.Domain.StateMachine
{
    [StateContextName("Find")]
    public class FindStateContext : BaseStateContext
    {
        public DateTime MinStartDate { get; set; }

        public DateTime MaxStartDate { get; set; }

        public FindStateContext(IEnumerable<IState> states, IRepository<ContextEntity> contextRepository) : base(states, contextRepository)
        {
            NextState = "AskEventList";
        }
    }
}