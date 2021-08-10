using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Entities;
using OneSchedule.Mongodb;
using OneSchedule.Services;
using OneSchedule.Settings;
using OneSchedule.ViewModels;
using System.Collections.Generic;

namespace OneSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IService<UserEntity> _service;
        private readonly IMapper _mapper;

        public TestController(DatabaseSettings settings, IMapper mapper)
        {
            _service = new UserService(new MongodbRepository<UserEntity>(settings));
            _mapper = mapper;
        }

        [HttpPost]
        public void Add([FromBody] UserView user)
        {
            var dbUser = _mapper.Map<UserEntity>(user);
            _service.AddAsync(dbUser);
        }

        [HttpGet]
        public ICollection<UserView> GetAll()
        {
            var result=_service.FindAsync(_=>true);
            return _mapper.Map<ICollection<UserView>>(result);
        }

        [HttpGet("{name}")]
        public UserView GetByName( string name)
        {
            var result = _service.FindFirstAsync(u => u.FirstName == name);
            return _mapper.Map<UserView>(result);
        }

        [HttpDelete("{name}")]
        public void DeleteByName(string name)
        {
            var user = _service.FindFirstAsync(u => u.FirstName == name).Result;
            if (user!=null)
            {
                _service.DeleteAsync(user.Id);
            }
        }

        [HttpPatch("{name}")]
        public void UpdateByName(string name, [FromBody] UserView user)
        {
            var existUser = _service.FindFirstAsync(u => u.FirstName == name).Result;
            if (existUser != null)
            {
                existUser.FirstName = user.FirstName;
                existUser.LastName = user.LastName;
                existUser.UserName = user.UserName;
                _service.UpdateAsync(existUser);
            }
        }
    }
}
