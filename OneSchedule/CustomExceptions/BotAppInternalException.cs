using System;

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
