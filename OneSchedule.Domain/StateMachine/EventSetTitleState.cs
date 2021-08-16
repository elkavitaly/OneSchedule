using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.Models;

namespace OneSchedule.Domain
{
    public class EventSetTitleState : IState
    {
        private EventContext _context;

        public void Handle(DtoDomain dtoDomain)
        {
            _context.EventDomain = new EventDomain();
            _context.EventDomain.Title = dtoDomain.MessageText;
        }

        public void SetContext(IStateMachineContext context)
        {
            _context = (EventContext)context;
        }
    }
}