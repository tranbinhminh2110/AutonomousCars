using BotTournamentManagement.Data;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Interface.IRepository;

namespace BotTournamentManagement.Repository
{
    public class TournamentRepository : BaseRepository<TournamentEntity>, ITournamentRepository
    {
        public TournamentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
