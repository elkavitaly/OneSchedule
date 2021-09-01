using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using OneSchedule.Settings;
using Serilog;
using Serilog.Formatting.Compact;
using System;

namespace OneSchedule
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .WriteTo.Console(new RenderedCompactJsonFormatter())
                .CreateLogger();

            Log.Information("Starting up!");

            try
            {
                CreateHostBuilder(args).Build().Run();

                Log.Information("Stopped cleanly");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "An unhandled exception occured during bootstrapping");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseConfiguredSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
