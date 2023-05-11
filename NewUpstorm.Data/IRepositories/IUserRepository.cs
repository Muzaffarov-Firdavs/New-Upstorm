using NewUpstorm.Domain.Entities;
using System.Linq.Expressions;

namespace NewUpstorm.Data.IRepositories
{
    public interface IUserRepository
    {
        ValueTask<User> InsertAsync(User user);
        ValueTask<User> UpdateAsync(User user);
        ValueTask<bool> DeleteAsync(Expression<Func<User, bool>> expression);
        ValueTask<User> SelectAsync(Expression<Func<User, bool>> expression);
        IQueryable<User> SelectAll();
    }
}
