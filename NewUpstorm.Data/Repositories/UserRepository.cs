using Microsoft.EntityFrameworkCore;
using NewUpstorm.Data.DbContexts;
using NewUpstorm.Data.IRepositories;
using NewUpstorm.Domain.Entities;
using System.Linq.Expressions;

namespace NewUpstorm.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext DbContext;
        public UserRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async ValueTask<bool> DeleteAsync(User user)
        {
            this.DbContext.Users.Remove(user);
            await this.DbContext.SaveChangesAsync();
            return true;
        }

        public async ValueTask<User> InsertAsync(User user)
        {
            var enteredUser = await this.DbContext.Users.AddAsync(user);
            await this.DbContext.SaveChangesAsync();
            return enteredUser.Entity;
        }

        public IQueryable<User> SelectAll(Expression<Func<User, bool>> expression = null)
        {
            if (expression is not null)
                return this.DbContext.Users.Where(expression);

            return this.DbContext.Users;
        }

        public async ValueTask<User> SelectAsync(Expression<Func<User, bool>> expression)
           => await this.DbContext.Users.FirstOrDefaultAsync(expression);

        public async ValueTask<User> UpdateAsync(User user)
        {
            var updatedUser = this.DbContext.Users.Update(user);
            await this.DbContext.SaveChangesAsync();
            return updatedUser.Entity;
        }
    }
}
