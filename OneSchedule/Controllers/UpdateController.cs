using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.Models;
using OneSchedule.Domain.Strategies;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace OneSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        private readonly StrategyContext _context;
        private readonly IMapper _mapper;


        public UpdateController(IService<UserDomain> service, IMapper mapper, StrategyContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task Post([FromBody] Update[] updates)
        {
            foreach (var update in updates)
            {
                var dto = _mapper.Map<DtoDomain>(update);
                await _context.ExecuteAsync(dto);
            }
        }
    }
}
