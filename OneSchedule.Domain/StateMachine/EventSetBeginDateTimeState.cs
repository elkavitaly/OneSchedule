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
    public class EventSetBeginDateTimeState : IBotState
    {
        private Context _context;
       
        public void Handle()
        {
            EventDomain eventDomain = _context.eventDomain;
            eventDomain.StartDate = DateTime.Parse(_context.update.Message.Text);
            
            _context.eventDomain = eventDomain;
            var nextStateRequestMessage = "Enter event end Date and time";

            _context.Bot.SendTextMessageAsync(eventDomain.ChatId, nextStateRequestMessage);

            var newState = new EventSetEndDateTimeState();
            _context.SetState(newState);
        }

        public void SetContext(IContext context)
        {
            _context = (Context)context;
        }
    }
}
