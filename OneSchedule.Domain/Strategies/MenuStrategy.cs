using OneSchedule.Attributes;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Abstractions.Strategies;
using OneSchedule.Domain.Models;
using OneSchedule.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneSchedule.Domain.Strategies
{
    [StrategyName("/menu")]
    public class MenuStrategy : IStrategy
    {
        private const string StateContext = "Menu";
        private readonly Dictionary<string, IStateContext> _stateContexts;

        public MenuStrategy(IEnumerable<IStateContext> contexts)
        {
            _stateContexts = contexts.ToDictionary(c => StateContextNameReader.GetStateContextName(c.GetType()));
        }

        public async Task ExecuteAsync(DtoDomain dto)
        {
            await _stateContexts[StateContext].HandleAsync(dto);
        }
    }
}
