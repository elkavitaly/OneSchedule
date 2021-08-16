using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using OneSchedule;

namespace OneSchedule.Domain
{
    public class EventSetTitleState : IState
    {
        private EventContext _context;

        public void Handle(string value)
        {
            _context.EventDomain = new EventDomain();
            _context.EventDomain.Title = value;
        }

        public void SetContext(IStateMachineContext context)
        {
            _context = (EventContext)context;
        }
    }
}