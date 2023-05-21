using Microsoft.AspNetCore.Mvc;
using NewUpstorm.Service.DTOs;
using NewUpstorm.Service.Interfaces;

namespace NewUpstorm.Web.Controllers
{
    public class AccountsController : BaseController
    {
        private readonly IAuthService authService;
        private readonly IUserService userService;
        public AccountsController(IAuthService authService, IUserService userService)
        {
            this.authService = authService;
            this.userService = userService;
        }

        [HttpPost]
        [Route("sign-up")]
        public async Task<IActionResult> PostUserAsync(UserCreationDto dto)
            => Ok(new
            {
                Code = 200,
                Message = "Success",
                Data = await this.userService.AddAsync(dto)
            });

        [HttpPost("generate-token")]
        public async Task<IActionResult> GenerateTokenAsync(string username, string passoword = null)
            => Ok(new
            {
                Code = 200,
                Message = "Success",
                Data = await this.authService.GenerateTokenASync(username, passoword)
            });
    }
}
