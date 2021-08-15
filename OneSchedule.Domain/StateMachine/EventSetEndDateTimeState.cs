using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using OneSchedule;
using DnsClient.Internal;
using Microsoft.Extensions.Logging;

namespace OneSchedule.Domain
{
    public class EventSetEndDateTimeState : IBotState
    {
        private Context _context;
        private EventDomain eventDomain;
       
        public EventSetEndDateTimeState()
        {

        }

        public void Handle()
        {
            
        }

        public void SetContext(IContext context)
        {
            _context = (Context)context;
        }
    }
}
