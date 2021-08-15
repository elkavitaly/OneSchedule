using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OneSchedule.Domain.Abstractions;
using OneSchedule.Domain.Models;
using OneSchedule.Entities;
using OneSchedule.ViewModels;
using System.Collections.Generic;

namespace OneSchedule.Controllers
{
    public class TestController : BaseController
    {

        private readonly IService<UserDomain> _service;
        private readonly IMapper _mapper;

        public TestController(IService<UserDomain> service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost]
        public ActionResult Add([FromBody] UserView user)
        {
            var dbUser = _mapper.Map<UserDomain>(user);

            _service.AddAsync(dbUser);

            return Ok();
        }

        [HttpGet]
        public ICollection<UserView> GetAll()
        {
            var result=_service.FindAsync(_=>true).Result;
            return _mapper.Map<ICollection<UserView>>(result);
        }

        [HttpGet("{name}")]
        public UserView GetByName( string name)
        {
            var result = _service.FindFirstAsync(u => u.FirstName == name).Result;
            return _mapper.Map<UserView>(result);
        }

        [HttpDelete("{name}")]
        public void DeleteByName(string name)
        {
            var user = _service.FindFirstAsync(u => u.FirstName == name).Result;
            if (user!=null)
            {
                var entityData = _mapper.Map<UserEntity>(user);
                _service.DeleteAsync(entityData.Id);
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
