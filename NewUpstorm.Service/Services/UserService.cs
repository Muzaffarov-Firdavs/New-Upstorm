using AutoMapper;
using NewUpstorm.Data.IRepositories;
using NewUpstorm.Domain.Entities;
using NewUpstorm.Service.DTOs;
using NewUpstorm.Service.Exceptions;
using NewUpstorm.Service.Interfaces;

namespace NewUpstorm.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async ValueTask<UserForResultDto> AddAsync(UserCreationDto userDto)
        {
            var user = await this.userRepository.SelectAsync(t => t.Email == userDto.Email);
            if (user is not null)
                throw new CustomException(403, "User already exist");

            var mappedUser = this.mapper.Map<User>(userDto);
            var result = await this.userRepository.InsertAsync(mappedUser);
            return this.mapper.Map<UserForResultDto>(result);
        }

        public async ValueTask<UserForResultDto> ModifyAsync(UserForUpdateDto userDto)
        {
            var updatingUser = await this.userRepository.SelectAsync(t => t.Id == userDto.Id);
            if (updatingUser is null)
                throw new CustomException(404, "User not found");

            this.mapper.Map(userDto, updatingUser);
            updatingUser.UpdatedAt = DateTime.UtcNow;
            var result = await this.userRepository.UpdateAsync(updatingUser);
            return this.mapper.Map<UserForResultDto>(result);
        }

        public async ValueTask<bool> RemoveAsync(long id)
        {
            var user = await this.userRepository.SelectAsync(t => t.Id == id);
            if (user is null)
                throw new CustomException(404, "User not found");

            return await this.userRepository.DeleteAsync(user);
        }

        public async ValueTask<IEnumerable<UserForResultDto>> RetriewAllAsync(string search = null)
        {
            var users = this.userRepository.SelectAll();
            var result = this.mapper.Map<IEnumerable<UserForResultDto>>(users);

            if (!string.IsNullOrEmpty(search))
                return result.Where(
                    u => u.FirstName.ToLower().Contains(search.ToLower()) ||
                    u.LastName.ToLower().Contains(search.ToLower()) ||
                    u.Email.ToLower().Contains(search.ToLower()))
                    .ToList();

            return result;
        }

        public async ValueTask<UserForResultDto> RetriewByIdAsync(long id)
        {
            var user = await this.userRepository.SelectAsync(t => t.Id == id);
            if (user is null)
                throw new CustomException(404, "User not found");

            return this.mapper.Map<UserForResultDto>(user);
        }

        public async ValueTask<UserForResultDto> ChangePaswordAsync(UserForPasswordDto userDto)
        {
            var existUser = await this.userRepository.SelectAsync(t => t.Email.ToLower() == userDto.Email.ToLower());
            if (existUser is null)
                throw new Exception("This username is not exist");
            else if (userDto.NewPasswword != userDto.ConfirmPassword)
                throw new Exception("New password and confirm password are not equal");
            else if (existUser.Password != userDto.NewPasswword)
                throw new Exception("Paassword is incorrect");

            existUser.Password = userDto.ConfirmPassword;
            await this.userRepository.UpdateAsync(existUser);
            return this.mapper.Map<UserForResultDto>(existUser);
        }

        public async ValueTask<UserForResultDto> UserVerify(string code)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<UserForResultDto> CheckUserAsync(string email, string password = null)
        {
            var user = await this.userRepository.SelectAsync(t => t.Email.ToLower() == email.ToLower());
            if (user is null)
                throw new CustomException(404, "User is not found");
            return this.mapper.Map<UserForResultDto>(user);
        }
    }
}
