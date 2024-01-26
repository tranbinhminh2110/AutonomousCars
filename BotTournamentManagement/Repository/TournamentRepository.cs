using BotTournamentManagement.Data;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel;
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
