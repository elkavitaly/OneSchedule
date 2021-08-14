
using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OneSchedule.Domain
{
    public class EventSetTitleState : IBotState
    {
        private Context _context;

        public void Handle() 
        {
            EventDomain eventDomain = new EventDomain();
            eventDomain.Title = _context.update.Message.Text;
            var newState = new EventSetDateTimeState();
            _context.SetState(newState);        
        }

        public void SetContext(IContext context)
        {
            _context = (Context)context;
        }
    }
}
