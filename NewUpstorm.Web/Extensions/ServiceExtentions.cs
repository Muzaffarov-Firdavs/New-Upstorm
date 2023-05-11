using NewUpstorm.Data.IRepositories;
using NewUpstorm.Data.Repositories;
using NewUpstorm.Service.Interfaces;
using NewUpstorm.Service.Services;

namespace NewUpstorm.Web.Extensions
{
    public static class ServiceExtentions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IForecastService, ForecastService>();

            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
