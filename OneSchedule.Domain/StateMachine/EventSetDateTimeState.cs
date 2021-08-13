using OneSchedule.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSchedule.Domain
{
    public class EventSetDateTimeState : IBotState
    {
        private Context _context;

        public void Handle()
        {
            
        }

        public void SetContext(IContext context)
        {
            _context = (Context)context;
        }
    }
}
