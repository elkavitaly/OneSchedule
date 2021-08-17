using OneSchedule.Attributes;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using OneSchedule.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneSchedule.Domain
{
    [StateName("SetTitle")]
    public class EventSetTitleState : IState
    {
        private const string SetBeginDateTime = "SetBeginDateTime";
       
        public void Handle(IStateContext stateContext, DtoDomain dtoDomain)
        {
            stateContext.EventEntity.Title = dtoDomain.MessageText;
            stateContext.SetState(SetBeginDateTime);
        }
    }
}