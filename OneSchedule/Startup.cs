using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OneSchedule.Data;
using OneSchedule.Domain;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.StateMachine;
using OneSchedule.Domain.Strategies;
using OneSchedule.Exceptions.ExceptionHandlingMiddleware;
using OneSchedule.Services;
using OneSchedule.Settings;
using Quartz;
using System;
using Serilog;
using NotificationSender = OneSchedule.Services.NotificationSender;

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

            services.Configure<QuartzOptions>(options =>
            {
                options.Scheduling.IgnoreDuplicates = true;
                options.Scheduling.OverWriteExistingData = true;
            });

            services.AddQuartz(q =>
            {
                q.SchedulerId = "Scheduler-Core";

                q.UseMicrosoftDependencyInjectionJobFactory();

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
            services.AddSingleton<INotificationSender, NotificationSender>();

            services.AddQuartzHostedService(options =>
            {
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

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
                endpoints.MapControllers();
            });
        }
    }
}
