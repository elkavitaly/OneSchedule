using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSchedule.Data.Abstractions
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; }

        public string DatabaseName { get; }
    }
}
