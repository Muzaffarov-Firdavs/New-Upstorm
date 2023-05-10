using Microsoft.EntityFrameworkCore;
using NewUpstorm.Domain;
using NewUpstorm.Domain.Entities;

namespace NewUpstorm.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
    }
}
