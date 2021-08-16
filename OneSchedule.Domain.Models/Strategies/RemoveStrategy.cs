﻿using OneSchedule.Attributes;
using System;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Models.Strategies
{
    [StrategyName("remove")]
    public class RemoveStrategy : IStrategy
    {
        public Task Execute(DtoDomain dto)
        {
            throw new NotImplementedException();
        }
    }
}
