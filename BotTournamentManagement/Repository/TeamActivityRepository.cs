using BotTournamentManagement.Data;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Interface.IRepository;

namespace BotTournamentManagement.Repository
{
    public class TeamActivityRepository : BaseRepository<TeamActivityEntity>, ITeamActivityRepository
    {
        public TeamActivityRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
    
}
