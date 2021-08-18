using Microsoft.Extensions.DependencyInjection;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.StateMachine.AskState;
using OneSchedule.Domain.StateMachine.GetState;

namespace OneSchedule.Domain.StateMachine
{
    public static class StateMachineConfiguration
    {
        public static IServiceCollection ConfigureStateMachine(this IServiceCollection services)
        {
            services.AddSingleton<IState, AskTitleState>();
            services.AddSingleton<IState, GetTitleState>();

            services.AddSingleton<IState, AskEndDateState>();
            services.AddSingleton<IState, GetEndDateState>();

            services.AddSingleton<IState, AskBeginDateState>();
            services.AddSingleton<IState, GetBeginDateState>();

            services.AddSingleton<IState, AskDescriptionState>();
            services.AddSingleton<IState, GetDescriptionState>();

            services.AddSingleton<IState, AskNotificationsState>();
            services.AddSingleton<IState, GetNotificationsState>();

            services.AddSingleton<IState, AskMainMenuState>();
            services.AddSingleton<IState, GetMainMenuState>();

            services.AddSingleton<IState, AskEventMenuState>();
            services.AddSingleton<IState, GetEventMenuState>();
            
            services.AddSingleton<IState, AskEventListState>();
            services.AddSingleton<IState, GetEventListState>();  
            
            services.AddSingleton<IState, AskShowEventListState>();
            services.AddSingleton<IState, GetEventListState>();

            services.AddSingleton<IStateContext, CreateStateContext>();
            services.AddSingleton<IStateContext, MenuStateContext>();
            services.AddSingleton<IStateContext, FindStateContext>();
            return services;
        }
    }
}
