using BotTournamentManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BotTournamentManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server =(local);database=BotTournamentManagement;uid=sa;pwd=12345;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeamEntity>()
                        .HasMany<TeamInMatchEntity>()
                        .WithOne()
                        .HasForeignKey(us => us.TeamId)
                        .IsRequired();

            modelBuilder.Entity<MatchEntity>()
                        .HasMany<TeamInMatchEntity>()
                        .WithOne()
                        .HasForeignKey(us => us.MatchId)
                        .IsRequired();

            modelBuilder.Entity<TeamInMatchEntity>()
                        .ToTable("TeamInMatch")
                        .HasKey(x => new { x.TeamId, x.MatchId });
        }

        public DbSet<MapEntity> Maps { get; set; }
        public DbSet<HighSchoolEntity> HighSchools { get; set; }
        public DbSet<MatchEntity> Matches { get; set; }
        public DbSet<RoundEntity> Rounds { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<TournamentEntity> Tournaments { get; set; }
        public DbSet<TeamResultEntity> TeamResults { get; set; }
        public DbSet<ActivityTypeEntity> ActivityTypes { get; set; }
        public DbSet<TeamActivityEntity> TeamActivities { get; set; }
        public DbSet<PlayerEntity> Players { get; set; }
        
    }
}
