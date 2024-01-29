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
            optionsBuilder.UseSqlServer("Server=tcp:fptbottournamentmanagement.database.windows.net,1433;Initial Catalog=BotTournamentManagement-dev;Persist Security Info=False;User ID=fptbottournament;Password=fptbotgame@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        

        public DbSet<MapEntity> Maps { get; set; }
        public DbSet<HighSchoolEntity> HighSchools { get; set; }
        public DbSet<MatchEntity> Matches { get; set; }
        public DbSet<RoundEntity> Rounds { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<TournamentEntity> Tournaments { get; set; }
        public DbSet<ActivityTypeEntity> ActivityTypes { get; set; }
        public DbSet<TeamActivityEntity> TeamActivities { get; set; }
        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TeamInMatchEntity> TeamInMatches { get; set; }
        
    }
}
