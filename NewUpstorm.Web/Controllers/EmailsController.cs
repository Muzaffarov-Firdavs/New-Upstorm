using Microsoft.AspNetCore.Mvc;
using NewUpstorm.Service.Interfaces;

namespace NewUpstorm.Web.Controllers
{
    public class EmailsController : BaseController
    {
        private readonly IEmailService emailService;
        public EmailsController(IEmailService emailService)
        {
            this.emailService = emailService;
        }


        [HttpPost]
        public async Task<IActionResult> SendVerifcationAsync(string email)
            => Ok(new
            {
                Code = 200,
                Message = "Success",
                Data = await this.emailService.SendEmailAsync(email)
            });
    }
}
