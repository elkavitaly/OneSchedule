using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OneSchedule.Data;
using OneSchedule.Domain;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.HealthCheck;
using OneSchedule.Domain.StateMachine;
using OneSchedule.Domain.Strategies;
using OneSchedule.Exceptions.ExceptionHandlingMiddleware;
using OneSchedule.Services;
using OneSchedule.Settings;
using Quartz;
using System;

namespace OneSchedule
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OneSchedule", Version = "v1" });
            });

            services.Configure<QuartzOptions>(Configuration.GetSection("Quartz"));

            // if you are using persistent job store, you might want to alter some options
            services.Configure<QuartzOptions>(options =>
            {
                options.Scheduling.IgnoreDuplicates = true; // default: false
                options.Scheduling.OverWriteExistingData = true; // default: true
            });

            services.AddQuartz(q =>
            {
                // handy when part of cluster or you want to otherwise identify multiple schedulers
                q.SchedulerId = "Scheduler-Core";

                // we take this from appsettings.json, just show it's possible
                // q.SchedulerName = "Quartz ASP.NET Core Sample Scheduler";

                // as of 3.3.2 this also injects scoped services (like EF DbContext) without problems
                q.UseMicrosoftDependencyInjectionJobFactory();

                // or for scoped service support like EF Core DbContext
                // q.UseMicrosoftDependencyInjectionScopedJobFactory();

                // these are the defaults
                q.UseSimpleTypeLoader();
                q.UseInMemoryStore();
                q.UseDefaultThreadPool(tp =>
                {
                    tp.MaxConcurrency = 10;
                });

                q.ScheduleJob<NotificationSenderJob>(trigger => trigger
                    .WithIdentity("Combined Configuration Trigger")
                    .StartAt(DateBuilder.EvenSecondDate(DateTimeOffset.UtcNow.AddSeconds(1)))
                    .WithDailyTimeIntervalSchedule(x => x.WithInterval(10, IntervalUnit.Second)));

            });

            services.Configure<TelegramSettings>(Configuration.GetSection(nameof(TelegramSettings)));
            services.ConfigureExceptionHandlingMiddleware(Configuration);
            services.ConfigureRepository(Configuration);
            services.ConfigureStrategy();
            services.ConfigureStateMachine();
            services.ConfigureService();
            services.AddSingleton<INotificationSender, Domain.NotificationSender>();
            services.AddTransient<NotificationSenderJob>();
            services.AddQuartzHostedService(options =>
            {
                // when shutting down we want jobs to complete gracefully
                options.WaitForJobsToComplete = true;
            });

            services.AddHealthChecks()
                .AddMongoDb(Configuration.GetSection(nameof(DatabaseSettings)).Get<DatabaseSettings>().ConnectionString)
                .AddUrlGroup(new Uri(Configuration.GetSection(nameof(TelegramSettings)).Get<TelegramSettings>().TestUri));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OneSchedule v1"));
            }

            app.UseExceptionHandlingMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
