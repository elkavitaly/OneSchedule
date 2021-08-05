using Application.DTOs;
using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotWebApi.Controllers
{
    public class NotificationController : BaseController
    {
        private INotificationService _service;

        public NotificationController(INotificationService service)
        {
            _service = service;
        }



        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] NotificationCreateModel model)
        {
            var dto = await _service.AddAsync(model);

            if (dto is null)
                return NotFound();

            return CreatedAtAction(nameof(GetByIdAsync), new { userId = model.UserId, eventId = model.EventId, notificationId = dto.Id }, dto);

        }

        [HttpGet]
        public async Task<ActionResult<NotificationDTO>> GetByIdAsync(
            [FromQuery] string userId,
            [FromQuery] string eventId,
            [FromQuery] string notificationId)
        {
            return OkOrNotFound(await _service.GetByIdAsync(userId, eventId, notificationId));
        }


        [HttpPut]
        public async Task<ActionResult<NotificationDTO>> EditAsync([FromBody] NotificationEditModel model)
        {
            var dto = await _service.EditAsync(model);

            if (dto is null)
                return NotFound();

            return CreatedAtAction(nameof(GetByIdAsync), new { userId = model.UserId, eventId = model.EventId, notificationId = dto.Id }, dto);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAsync([FromQuery] string userId, [FromQuery] string eventId, [FromQuery] string notificationId)
        {
            var isDeleted = await _service.DeleteAsync(userId, eventId, notificationId);

            if (!isDeleted)
                return NotFound();

            return CreatedAtAction(nameof(GetAllAsync), new { userId = userId, eventId = eventId });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificationDTO>>> GetAllAsync([FromQuery] string userId, [FromQuery] string eventId)
        {
            return OkOrNotFound(await _service.GetAllAsync(userId, eventId));
        }




    }
}
