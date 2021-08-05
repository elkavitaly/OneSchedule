using Application.DTOs;
using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotWebApi.Controllers
{
    public class UserController : BaseController
    {
        private IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] UserCreateModel model)
        {
            var dto = await _service.AddAsync(model);

            if (dto is null)
                return NotFound();

            return CreatedAtAction(nameof(GetByIdAsync), new { id = dto.Id }, dto);
        }

        [HttpGet("[controller]/{id}")]
        public async Task<ActionResult<UserDTO>> GetByIdAsync([FromRoute] string id)
        {
            return OkOrNotFound(await _service.GetByIdAsync(id));
        }


        [HttpPut]
        public async Task<ActionResult<UserDTO>> EditAsync([FromBody] UserEditModel model)
        {
            var dto = await _service.EditAsync(model);

            if (dto is null)
                return NotFound();

            return CreatedAtAction(nameof(GetByIdAsync), new { id = dto.Id }, dto);
        }

        [HttpDelete("[controller]/[action]/{id}")]
        public async Task<ActionResult<bool>> DeleteAsync([FromRoute] string id)
        {
            var isDeleted = await _service.DeleteAsync(id);

            if (!isDeleted)
                return NotFound();

            return CreatedAtAction(nameof(GetAllAsync), null);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllAsync()
        {
            return OkOrNotFound(await _service.GetAllAsync());
        }
    }
}
