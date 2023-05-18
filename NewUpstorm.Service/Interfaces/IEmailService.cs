namespace NewUpstorm.Service.Interfaces
{
    public interface IEmailService
    {
        ValueTask<string> SendEmailAsync(string to);
    }
}
