using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSchedule
{
    class BotAppInternalException : Exception
    {
        public BotAppInternalException()
        {
        }

        public BotAppInternalException(string message)
            : base(message)
        {
        }

        public BotAppInternalException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
