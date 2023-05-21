namespace NewUpstorm.Service.Interfaces
{
    public interface IAuthService
    {
        ValueTask<string> GenerateTokenASync(string email, string password);
    }
}
