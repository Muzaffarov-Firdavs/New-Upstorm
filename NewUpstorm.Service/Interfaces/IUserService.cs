using NewUpstorm.Service.DTOs;

namespace NewUpstorm.Service.Interfaces
{
    public interface IUserService
    {
        ValueTask<UserForResultDto> AddUserAsync(UserCreationDto userDto);
        ValueTask<bool> RemoveUserAsync(long id);
        ValueTask<UserForResultDto> ModifyUserAsync(long id, UserForUpdateDto userDto);
        ValueTask<UserForResultDto> RetriewByIdAsync(long id);
        ValueTask<IEnumerable<UserForResultDto>> RetriewAllAsync();
    }
}
