using Microsoft.Extensions.Configuration;
using NewUpstorm.Service.Interfaces;

namespace NewUpstorm.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService userService;
        private readonly IConfiguration configuration;
        public AuthService(IUserService userService, IConfiguration configuration)
        {
            this.userService = userService;
            this.configuration = configuration;
        }

        public async ValueTask<string> GenerateTokenASync(string surename, string password)
        {
            var user = await this.userService.check
        }

    }
}
