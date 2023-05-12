using Microsoft.AspNetCore.Mvc;
using NewUpstorm.Service.DTOs;
using NewUpstorm.Service.Interfaces;

namespace NewUpstorm.Web.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> PostAsync(UserCreationDto dto)
            => Ok(await this.userService.AddAsync(dto));

        [HttpPut("post")]
        public async Task<IActionResult> PutAsync(UserForUpdateDto dto)
            => Ok(await this.userService.ModifyAsync(dto));

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(long id)
            => Ok(await this.userService.RemoveAsync(id));

        [HttpGet("id")]
        public async Task<IActionResult> GetAsync(long id)
            => Ok(await this.userService.RetriewByIdAsync(id));

        [HttpGet("list")]
        public async Task<IActionResult> GetAllAsync([FromForm]string search = null)
            => Ok(await this.userService.RetriewAllAsync(search));
    }
}
