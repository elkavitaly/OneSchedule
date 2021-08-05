using Application;
using Application.Exceptions;
using Application.Mapper;
using Application.Services;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using FluentValidation.AspNetCore;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System;
using System.Data;
using System.Net;
using System.Text.Json;

namespace BotWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddScheduleDatabaseSettings(services);
            AddMongoClientAndDatabase(services);
            AddRepositories(services);
            AddAutoMapper(services);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<INotificationService, NotificationService>();

            services.AddControllers()
                .AddFluentValidation(options =>
                options.RegisterValidatorsFromAssemblyContaining<ApplicationLayerEntryPoint>());


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BotWebApi", Version = "v1" });
            });
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseExceptionHandler(ConfigureDevelopmentException);
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BotWebApi v1");

                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IRepository<User>>(options =>
                            new Repository<User>(options.GetService<IMongoDatabase>(), options.GetService<IScheduleDatabaseSettings>().UserCollectionName));
        }

        private void AddScheduleDatabaseSettings(IServiceCollection services)
        {
            services.Configure<ScheduleDatabaseSettings>(
                Configuration.GetSection(nameof(ScheduleDatabaseSettings)));

            services.AddSingleton<IScheduleDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ScheduleDatabaseSettings>>().Value);
        }

        private static void AddMongoClientAndDatabase(IServiceCollection services)
        {
            services.AddSingleton<IMongoClient>(options =>
                                new MongoClient(options.GetService<IScheduleDatabaseSettings>().ConnectionString));

            services.AddScoped(client => client.GetService<IMongoClient>().StartSession());

            services.AddScoped<IMongoDatabase>(options =>
                    (MongoDatabaseBase)options.GetService<IMongoClient>()
                                              .GetDatabase(options.GetService<IScheduleDatabaseSettings>().DatabaseName));
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(options =>
            {
                options.AddProfile(new MappingProfile());
            });

            services.AddSingleton(mappingConfig.CreateMapper());
        }

        public Action<IApplicationBuilder> ConfigureDevelopmentException = app =>
            app.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    string message;

                    if (exceptionFeature?.Error is BaseApplicationException)
                    {
                        var baseApplicationException = (BaseApplicationException)(exceptionFeature?.Error);
                        context.Response.StatusCode = (int)baseApplicationException.HttpStatusCode;

                        message = exceptionFeature.Error.Message;
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        if (exceptionFeature?.Error is DataException)
                            message = "Database error!";
                        else
                            message = "Unknown error!";
                    }

                    await context.Response.WriteAsync(JsonSerializer.Serialize(new
                    {
                        StatusCode = context.Response.StatusCode,
                        Method = context.Request.Method,
                        Message = message
                    }));
                });
    }
}
