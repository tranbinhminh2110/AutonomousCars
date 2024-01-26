using BotTournamentManagement.Data;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Interface.IRepository;

namespace BotTournamentManagement.Repository
{
    public class TeamRepository : BaseRepository<TeamEntity>, ITeamRepository
    {
        public TeamRepository(AppDbContext appDbContext) : base(appDbContext) 
        {

        }
    }
}
