using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Abstractions
{
    class OneScheduleInternalException
        : Exception
    {
        public OneScheduleInternalException()
        {
        }

        public OneScheduleInternalException(string message)
            : base(message)
        {
        }

        public OneScheduleInternalException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
