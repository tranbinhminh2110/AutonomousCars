using BotTournamentManagement.Data;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel.TeamInMatchModel;
using BotTournamentManagement.Interface.IRepository;

namespace BotTournamentManagement.Repository
{
    public class TeamInMatchRepository : BaseRepository<TeamInMatchEntity>, ITeamInMatchRepository
    {
        public TeamInMatchRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
