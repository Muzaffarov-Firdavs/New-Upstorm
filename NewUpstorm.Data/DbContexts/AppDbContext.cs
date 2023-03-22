using Microsoft.EntityFrameworkCore;
using NewUpstorm.Domain;
using NewUpstorm.Domain.Entities;

namespace NewUpstorm.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = "Server=(localdb)\\mssqllocaldb;Database=MyUpstorm;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(path);
        }
    }
}
