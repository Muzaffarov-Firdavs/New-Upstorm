using MimeKit;
using NewUpstorm.Service.Interfaces;
using StackExchange.Redis;

namespace NewUpstorm.Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailService emailService;
        public EmailService(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public ValueTask<string> SendEmailAsync(string to)
        {
            try
            {
                Random random = new Random();
                int verificationCode = random.Next(123456, 999999);

                ConnectionMultiplexer redisConnect = ConnectionMultiplexer.Connect("localhost");
                IDatabase db = redisConnect.GetDatabase();
                db.StringSet("code", verificationCode.ToString());
                var result = db.StringGet("code");

                var email = new MimeMessage();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
