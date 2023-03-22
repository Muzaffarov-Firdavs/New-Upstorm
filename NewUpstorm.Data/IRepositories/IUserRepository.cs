using NewUpstorm.Domain.Entities;

namespace NewUpstorm.Data.IRepositories
{
    public interface IUserRepository
    {
        ValueTask<User> InsertUserAsync(User user);
        ValueTask<User> UpdateUserAsync(long id, User user);
        ValueTask<bool> DeleteUserAsync(long id);
        ValueTask<User> SelectUserByIdAsync(long id);
        IQueryable<User> SelectAllUsers();
    }
}
