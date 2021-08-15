using Microsoft.Extensions.DependencyInjection;
using OneSchedule.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSchedule.Domain.StateMachine
{
    public static class StateMachineConfiguration
    {
        public static IServiceCollection ConfigureStateMachine(this IServiceCollection services)
        {
            services.AddSingleton<IStateMachineContext, StateMachineContext>();
            services.AddTransient<IStateMachineState, StateMachineState>();
            return services;
        }
    }
}
