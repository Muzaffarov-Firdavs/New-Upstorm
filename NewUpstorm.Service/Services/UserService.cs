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
        IUserRepository userRepository = new UserRepository();


        public async ValueTask<Response<UserDto>> AddUserAsync(UserDto userDto)
        {
            List<User> existingUser = (userRepository.SelectAllUsers())
                        .Where(u => u.Username == userDto.Username).Take(1).ToList();
            if (existingUser.Any())
                return new Response<UserDto>
                {
                    StatusCode = 400,
                    Message = "Username is already taken"
                };

            User mappedUser = new User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Username = userDto.Username,
                Password = userDto.Password,
                UserRole = userDto.UserRole,
                City = userDto.City,
                CreatedAt = DateTime.UtcNow,
            };

            User insertedUser = await userRepository.InsertUserAsync(mappedUser);

            UserDto mappedUserDto = new UserDto()
            {
                FirstName = insertedUser.FirstName,
                LastName = insertedUser.LastName,
                Username = insertedUser.Username,
                Password = insertedUser.Password,
                UserRole = insertedUser.UserRole,
                City = insertedUser.City,
            };

            return new Response<UserDto>
            {
                StatusCode = 200,
                Message = "Success",
                Value = mappedUserDto
            };
        }

        public async ValueTask<Response<bool>> RemoveUserAsync(long id)
        {
            User exisingUser = await userRepository.SelectUserByIdAsync(id);
            if (exisingUser is null)
                return new Response<bool>
                {
                    StatusCode = 404,
                    Message = "Not found",
                    Value = false
                };

            await userRepository.DeleteUserAsync(id);
            return new Response<bool>
            {
                StatusCode = 200,
                Message = "Success",
                Value = true
            };
        }

        public async ValueTask<Response<List<UserDto>>> GetAllUsersAsync()
        {
            List<User> users = userRepository.SelectAllUsers().ToList();

            List<UserDto> userDtos = new List<UserDto>();

            foreach (User user in users)
            {
                userDtos.Add(new UserDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username,
                    Password = user.Password,
                    UserRole = user.UserRole,
                    City = user.City,
                });
            }

            return new Response<List<UserDto>>
            {
                StatusCode = 200,
                Message = "Success",
                Value = userDtos
            };
        }

        public async ValueTask<Response<UserDto>> GetUserByIdAsync(long id)
        {
            User user = await userRepository.SelectUserByIdAsync(id);
            if (user is null)
                return new Response<UserDto>
                {
                    StatusCode = 404,
                    Message = "Not found"
                };

            UserDto mappedUserDto = new UserDto()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Password = user.Password,
                UserRole = user.UserRole,
                City = user.City
            };

            return new Response<UserDto>
            {
                StatusCode = 200,
                Message = "Success",
                Value = mappedUserDto
            };
        }

        public async ValueTask<Response<UserDto>> UpdateUserAsync(long id, UserDto userDto)
        {
            var res = userRepository.SelectAllUsers();
            var existedUser = res.FirstOrDefault(i => i.Id == id);


            if (existedUser is null)
                return new Response<UserDto>
                {
                    StatusCode = 404,
                    Message = "Not found"
                };

            existedUser.FirstName = userDto.FirstName;
            existedUser.LastName = userDto.LastName;
            existedUser.Username = userDto.Username;
            existedUser.Password = userDto.Password;
            existedUser.UserRole = userDto.UserRole;
            existedUser.City = userDto.City;
            existedUser.UpdatedAt = DateTime.UtcNow;

            User updatedUser = await userRepository.UpdateUserAsync(id, existedUser);

            UserDto mappedUserDto = new UserDto()
            {
                FirstName = updatedUser.FirstName,
                LastName = updatedUser.LastName,
                Username = updatedUser.Username,
                Password = updatedUser.Password,
                UserRole = updatedUser.UserRole,
                City = updatedUser.City,
            };

            return new Response<UserDto>
            {
                StatusCode = 200,
                Message = "Success",
                Value = mappedUserDto
            };
        }
    }
}
