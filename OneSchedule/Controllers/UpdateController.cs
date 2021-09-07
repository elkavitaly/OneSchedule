using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace OneSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        private readonly IStateContext _context;
        private readonly IMapper _mapper;

        public UpdateController(IMapper mapper, IStateContext context)
        {
            _context = context;
            _mapper = mapper;
        } 

        [HttpPost]
        public async Task Post([FromBody] Update update)
        {
            var dto = _mapper.Map<DtoDomain>(update);
            await _context.HandleAsync(dto);
        }
    }
}
