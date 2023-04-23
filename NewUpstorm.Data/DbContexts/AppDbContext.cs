using Microsoft.EntityFrameworkCore;
using NewUpstorm.Domain;
using NewUpstorm.Domain.Entities;

namespace NewUpstorm.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WindInfo> WindInfos { get; set; }
        public virtual DbSet<SunTime> SunTimes { get; set; }
        public virtual DbSet<MainInfo> MainInfos { get; set; }
        public virtual DbSet<RootObject> RootObjects { get; set; }
        public virtual DbSet<WeatherInfo> WeatherInfos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = "Server=(localdb)\\mssqllocaldb;Database=MyUpstorm;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(path);
        }
    }
}
