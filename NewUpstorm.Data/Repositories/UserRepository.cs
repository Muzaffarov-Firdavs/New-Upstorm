using Microsoft.EntityFrameworkCore;
using NewUpstorm.Data.DbContexts;
using NewUpstorm.Data.IRepositories;
using NewUpstorm.Domain.Entities;

namespace NewUpstorm.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext DbContext = new AppDbContext();


        public async ValueTask<User> InsertUserAsync(User user)
        {
            var insertedUser = await DbContext.Users.AddAsync(user);
            DbContext.SaveChanges();
            return insertedUser.Entity;
        }

        public async ValueTask<bool> DeleteUserAsync(long id)
        {
            User model = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (model is null)
                return false;

            DbContext.Users.Remove(model);
            DbContext.SaveChanges();
            return true;
        }

        public IQueryable<User> SelectAllUsers()
        {
            return DbContext.Users.Where(user => true);
        }

        public async ValueTask<User> SelectUserByIdAsync(long id)
        {
            return await DbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async ValueTask<User> UpdateUserAsync(long id, User user)
        {
            user.Id = id;
            var res = DbContext.Users.Update(user);
            DbContext.SaveChanges();
            return res.Entity;

            
        }
    }
}
