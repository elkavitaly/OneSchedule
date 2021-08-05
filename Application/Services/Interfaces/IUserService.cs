using Application.DTOs;
using Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> AddAsync(UserCreateModel model);

        public Task<UserDTO> GetByIdAsync(string id);


        public Task<UserDTO> EditAsync(UserEditModel model);

        public Task<bool> DeleteAsync(string id);

        public Task<IEnumerable<UserDTO>> GetAllAsync();
    }
}
