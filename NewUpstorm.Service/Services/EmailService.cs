using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using NewUpstorm.Service.Exceptions;
using NewUpstorm.Service.Interfaces;
using StackExchange.Redis;

namespace NewUpstorm.Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;
        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async ValueTask<string> SendEmailAsync(string to)
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
                email.From.Add(MailboxAddress.Parse(this.configuration["EmailAddress"]));
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = "Email verification upstorm.uz";
                email.Body = new TextPart(TextFormat.Html) { Text = verificationCode.ToString() };

                var sendMessage = new SmtpClient();
                await sendMessage.ConnectAsync(this.configuration["Host"], 587, SecureSocketOptions.StartTls);
                await sendMessage.AuthenticateAsync(this.configuration["EmailAddress"], this.configuration["Password"]);
                await sendMessage.SendAsync(email);
                await sendMessage.DisconnectAsync(true);

                return verificationCode.ToString();
            }
            catch (Exception ex)
            {
                throw new CustomException(400, ex.Message);
            }
        }
    }
}