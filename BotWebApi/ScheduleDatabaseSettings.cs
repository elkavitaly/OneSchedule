using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotWebApi
{
    public class ScheduleDatabaseSettings : IScheduleDatabaseSettings
    {
        public string UserCollectionName { get; set; }
        public string ConnectionString { get; set; } 
        public string DatabaseName { get; set; }
    }
}
