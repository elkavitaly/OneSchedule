
using OneSchedule.Domain.Abstractions;
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
            var newState = new EventSetDateTimeState();
            _context.SetState(newState);        
        }

        public void SetContext(IContext context)
        {
            _context = (Context)context;
        }
    }
}
