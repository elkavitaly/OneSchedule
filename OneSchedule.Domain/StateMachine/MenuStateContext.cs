﻿using OneSchedule.Attributes;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Entities;
using System.Collections.Generic;

namespace OneSchedule.Domain.StateMachine
{
    [StateContextName("Menu")]
    public class MenuStateContext : BaseStateContext
    {
        public MenuStateContext(IEnumerable<IState> states, IRepository<ContextEntity> contextRepository) : base(states, contextRepository)
        {
            NextState = "AskMainMenu";
        }
    }
}