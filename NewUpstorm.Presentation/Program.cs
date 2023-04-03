using NewUpstorm.Data.IRepositories;
using NewUpstorm.Data.Repositories;
using NewUpstorm.Domain.Entities;
using NewUpstorm.Service.DTOs;
using NewUpstorm.Service.Interfaces;
using NewUpstorm.Service.Services;


IForecastRepository forecastRepository = new ForecastRepository();

var take = await forecastRepository.SelectCurrentForecastAsync("Tashkent");



IUserService userService = new UserService();
IUserRepository userRepository = new UserRepository();

UserDto dto = new UserDto()
{
    City = "Istambul",
    FirstName = "sayyoh",
    LastName = "kocha",
    Password = "2013",
    Username = "john",
    UserRole = NewUpstorm.Domain.Enums.UserRole.Consumer,
};

var entry = await userService.UpdateUserAsync(4, dto);
Console.WriteLine(entry.Message);



