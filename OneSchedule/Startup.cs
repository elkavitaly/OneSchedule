using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using OneSchedule.Data.Abstractions;
using OneSchedule.Entities;
using OneSchedule.Mongodb;
using OneSchedule.Services;
using OneSchedule.Settings;
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
            services.AddAutoMapper(typeof(DatabaseSettings).Assembly);

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OneSchedule", Version = "v1" });
            });

            services.Configure<TelegramSettings>(Configuration.GetSection(nameof(TelegramSettings)));
            services.AddSingleton(options => options.GetService<IOptions<TelegramSettings>>().Value);

            services.AddScheduleDatabaseSettings(Configuration);
            services.AddMongoClientAndDatabase();
            services.AddRepositories();

            services.ConfigureService();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OneSchedule v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
