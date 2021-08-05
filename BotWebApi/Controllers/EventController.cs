using Application.DTOs;
using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotWebApi.Controllers
{
    public class EventController : BaseController
    {
        private IEventService _service;

        public EventController(IEventService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] EventCreateModel model)
        {
            var dto = await _service.AddAsync(model);

            if (dto is null)
                return NotFound();

            return CreatedAtAction(nameof(GetByIdAsync), new { userId = model.UserId, eventId = dto.Id }, dto);

        }

        [HttpGet]
        public async Task<ActionResult<EventDTO>> GetByIdAsync([FromQuery] string userId, [FromQuery] string eventId)
        {
            return OkOrNotFound(await _service.GetByIdAsync(userId, eventId));
        }


        [HttpPut]
        public async Task<ActionResult<EventDTO>> EditAsync([FromBody] EventEditModel model)
        {
            var dto = await _service.EditAsync(model);

            if (dto is null)
                return NotFound();

            return CreatedAtAction(nameof(GetByIdAsync), new { userId = model.UserId, eventId = dto.Id }, dto);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAsync([FromQuery] string userId, [FromQuery] string eventId)
        {
            var isDeleted = await _service.DeleteAsync(userId, eventId);

            if (!isDeleted)
                return NotFound();

            return CreatedAtAction(nameof(GetAllAsync), new { userId = userId });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDTO>>> GetAllAsync(string userId)
        {
            return OkOrNotFound(await _service.GetAllAsync(userId));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDTO>>> GetAllByPeriodAsync([FromQuery] string userId, [FromQuery] PeriodModel period)
        {
            return OkOrNotFound(await _service.GetAllByPeriodAsync(userId, period));
        }


    }
}
