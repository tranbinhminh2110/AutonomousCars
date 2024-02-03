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
            optionsBuilder.UseSqlServer(GetConnectionString());
        }
        private string GetConnectionString() 
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
            var strConn = config["ConnectionString:DefaultConnectionStringDB"];
            return strConn;
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
