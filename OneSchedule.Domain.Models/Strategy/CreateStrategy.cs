﻿using System;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Models.Strategy
{
    public class CreateStrategy: IStrategy
    {
        public Task Execute(EventDomain eventDomain)
        {
            throw new NotImplementedException();
        }
    }
}
