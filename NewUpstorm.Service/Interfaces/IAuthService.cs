namespace NewUpstorm.Service.Interfaces
{
    public interface IAuthService
    {
        ValueTask<string> GenerateTokenASync(string surename, string password);
    }
}
