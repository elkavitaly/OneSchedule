using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using System;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Abstractions.StateMachine
{
    public interface IStateContext
    {
        public ContextEntity ContextEntity { get; set; }

        public DateTime MinStartDate { get; set; }

        public DateTime MaxStartDate { get; set; }

        public bool IsContextCompleted { get; }

        public Task HandleAsync(DtoDomain dtoDomain);

        public Task Execute(DtoDomain dtoDomain);

        public void SetState(string state);
    }
}
