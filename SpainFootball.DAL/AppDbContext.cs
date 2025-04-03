using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpainFootball.DAL.Enteties;

namespace SpainFootball.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players {  get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<ScoringPlayer> ScoringPlayers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var conStr = connection.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(conStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Team1)
                .WithMany(t => t.HomeMatches)
                .HasForeignKey(m => m.Team1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Team2)
                .WithMany(t => t.AwayMatches)
                .HasForeignKey(m => m.Team2Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ScoringPlayer>()
                .HasKey(mp => new { mp.MatchId, mp.PlayerId });

            modelBuilder.Entity<ScoringPlayer>()
                .HasOne(pm => pm.Player)
                .WithMany(p => p.ScoringPlayers)
                .HasForeignKey(pm => pm.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ScoringPlayer>()
                .HasOne(pm => pm.Match)
                .WithMany(m => m.ScoringPlayers)
                .HasForeignKey(pm => pm.MatchId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
