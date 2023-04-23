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
        public virtual DbSet<WindInfo> WindInfos { get; set; }
        public virtual DbSet<SunTime> SunTimes { get; set; }
        public virtual DbSet<MainInfo> MainInfos { get; set; }
        public virtual DbSet<RootObject> RootObjects { get; set; }
        public virtual DbSet<WeatherInfo> WeatherInfos { get; set; }


    }
}
