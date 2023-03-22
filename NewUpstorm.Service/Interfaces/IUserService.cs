using NewUpstorm.Service.DTOs;
using NewUpstorm.Service.Helpers;

namespace NewUpstorm.Service.Interfaces
{
    public interface IUserService
    {
        ValueTask<Response<UserDto>> AddUserAsync(UserDto userDto);
        ValueTask<Response<bool>> RemoveUserAsync(long id);
        ValueTask<Response<UserDto>> UpdateUserAsync(long id, UserDto userDto);
        ValueTask<Response<UserDto>> GetUserByIdAsync(long id);
        ValueTask<Response<List<UserDto>>> GetAllUsersAsync();
    }
}
