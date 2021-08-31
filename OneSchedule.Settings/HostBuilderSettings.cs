﻿using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Compact;

namespace OneSchedule.Settings
{
    public static class HostBuilderSettings
    {
        public static IHostBuilder UseConfiguredSerilog(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseSerilog((context, services, configuration) => configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .WriteTo.Console(new RenderedCompactJsonFormatter()));
            return hostBuilder;
        }
    }
}
