using NewUpstorm.Service.DTOs;

namespace NewUpstorm.Service.Interfaces
{
    public interface IUserService
    {
        ValueTask<UserForResultDto> AddAsync(UserCreationDto userDto);
        ValueTask<bool> RemoveAsync(long id);
        ValueTask<UserForResultDto> ModifyAsync(UserForUpdateDto userDto);
        ValueTask<UserForResultDto> RetriewByIdAsync(long id);
        ValueTask<IEnumerable<UserForResultDto>> RetriewAllAsync(string search = null);
        ValueTask<UserForResultDto> ChangePaswordAsync(UserForPasswordDto userDto);
        ValueTask<UserForResultDto> CheckUserAsync(string email, string password = null);
        ValueTask<UserForResultDto> UserVerify(string code);
    }
}
