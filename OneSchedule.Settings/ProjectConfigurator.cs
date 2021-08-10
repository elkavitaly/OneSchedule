using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IConfiguration = AutoMapper.Configuration.IConfiguration;

namespace OneSchedule.Settings
{
    public class ProjectConfigurator
    {
        public List<IConfiguration> Configurations { get; }
        public ProjectConfigurator()
        {
            Configurations = new List<IConfiguration>()
            {
                new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                    .Build()
            };
        }

    }
}
