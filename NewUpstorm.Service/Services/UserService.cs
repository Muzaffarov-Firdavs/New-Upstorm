using NewUpstorm.Data.IRepositories;
using NewUpstorm.Data.Repositories;
using NewUpstorm.Domain.Entities;
using NewUpstorm.Service.DTOs;
using NewUpstorm.Service.Helpers;
using NewUpstorm.Service.Interfaces;

namespace NewUpstorm.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async ValueTask<UserForResultDto> AddUserAsync(UserCreationDto userDto)
        {
            var user = await this.userRepository.SelectUserByIdAsync()
        }

        public ValueTask<UserForResultDto> ModifyUserAsync(long id, UserForUpdateDto userDto)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> RemoveUserAsync(long id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<UserForResultDto>> RetriewAllAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<UserForResultDto> RetriewByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
