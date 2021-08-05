using Application.DTOs;
using Application.Models;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IMapper mapper, IRepository<User> repository) : base(mapper, repository) { }



        public async Task<UserDTO> AddAsync(UserCreateModel model)
        {
            var user = _mapper.Map<User>(model);

            var userCreated = await _repository.AddAsync(user);

            return _mapper.Map<UserDTO>(userCreated);
        }


        public async Task<UserDTO> GetByIdAsync(string id)
        {
            var user = await _repository.GetByIdAsync(id);

            return _mapper.Map<UserDTO>(user);
        }


        public async Task<UserDTO> EditAsync(UserEditModel model)
        {
            var editUser = _mapper.Map<User>(model);

            var user = await _repository.GetByIdAsync(model.Id);

            if (user is null)
                return null;

            user.FirstName = editUser.FirstName;
            user.LastName = editUser.LastName;
            user.PhoneNumber = editUser.PhoneNumber;

            await _repository.UpdateAsync(user.Id, user);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user is null)
                return false;

            await _repository.DeleteAsync(user);

            return true;
        }


        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(await _repository.GetAllAsync());
        }


    }
}
