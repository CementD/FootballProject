using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SpainFootball.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var conStr = connection.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(conStr);
        }
    }
}
