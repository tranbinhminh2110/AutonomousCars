using BotTournamentManagement.Data;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Interface.IRepository;

namespace BotTournamentManagement.Repository
{
    public class MatchRepository : BaseRepository<MatchEntity>, IMatchRepository
    {
        public MatchRepository(AppDbContext appDbContext) : base(appDbContext) 
        { 
        }
    }
}
